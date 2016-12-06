-- подсчет чеков для расписаний смен сотрудников
CREATE FUNCTION [dbo].[GetSalePlanAverageForScheduleShift]
(     
     @PlatformId				int,
	 @SubDepartamentId			int, --подотдел, по которому формируется план продаж
	 @Average_SubDepartamentId	int, --подотдел, по которому считаем среднее
	 @DateBegin					DATETIME,
	 @DateEnd					DATETIME
)
RETURNS  
@RESULT TABLE
(
	[Date]	DATETIME,
	[COUNT]	INT
)
AS 
BEGIN
	DECLARE @CONSTANT_Suchi_PlanTypeId INT
	DECLARE @CONSTANT_Pizza_PlanTypeId INT
    DECLARE @CONSTANT_DAY_AVERAGE INT
	DECLARE @CONSTANT_MONTH_AVERAGE INT

	SET @CONSTANT_DAY_AVERAGE = 3 --количество дней для подсчета среднего
	SET @CONSTANT_MONTH_AVERAGE = -3 --количество месяцев для подсчета среднего

	SET @CONSTANT_Suchi_PlanTypeId = (SELECT id FROM dbo.PlanTypes WHERE Guid = 'D4C8C9C0-EA2F-47B6-8156-3030153AB8F4')
	SET @CONSTANT_Pizza_PlanTypeId = (SELECT id FROM dbo.PlanTypes WHERE Guid = '5DE8DA4E-8E06-47B9-975E-354BAF1D41CE')


	--таблица с подсчетами (сколько чеков планируется на этот день)
	DECLARE @RESULT_SALE_PLAN TABLE
	(
		[Date]			datetime, 
		[SUCHI_COUNT]	int, 
		[PIZZA_COUNT]	int,
		[AVERAGE]		int
	)

	--чеки за -3 месяца до текущей даты
	DECLARE @SALE_CHECK_ON_DATE TABLE
	(
		[Date]				datetime, 
		[SUCHI_COUNT]		int,
		[SALE_CHECK_COUNT]	int
	)

	--временая таблица, для подсчета ближайших дат с кол-вом чеками +- 10 шт
	DECLARE @SALE_CHECK_ON_DATE_AVERAGE TABLE
	(
		[Date]		datetime, 
		[COUNT]		int
	)

	--период для подсчета
	INSERT INTO @RESULT_SALE_PLAN
	(
		[Date]
	)
	SELECT 
		[Date]
	FROM 
		[dbo].[GetDateRange]('d', @DateBegin, @DateEnd) 


    -- план продаж по суши
    UPDATE
			@RESULT_SALE_PLAN
	SET
			SUCHI_COUNT =  (
							SELECT		
									SUM(ISNULL(spd.Delivery, 0) + ISNULL(spd.Self, 0))
							FROM		
									dbo.SalePlanDays spd
							INNER JOIN dbo.SalePlans sp ON sp.PlatformId = @PlatformId AND sp.Id = spd.SalePlanId AND sp.PlanTypeId = @CONSTANT_Suchi_PlanTypeId
							WHERE
									spd.[Date] = r.[Date]
							)
	 FROM
			@RESULT_SALE_PLAN r


   -- план продаж по пицце
   UPDATE
			@RESULT_SALE_PLAN
	SET
			PIZZA_COUNT =  (
							SELECT		
									SUM(ISNULL(spd.Delivery, 0) + ISNULL(spd.Self, 0))
							FROM		
									dbo.SalePlanDays spd
							INNER JOIN dbo.SalePlans sp ON sp.PlatformId = @PlatformId AND sp.Id = spd.SalePlanId AND sp.PlanTypeId = @CONSTANT_Pizza_PlanTypeId
							WHERE
									spd.[Date] = r.[Date] 
							)
	 FROM
			@RESULT_SALE_PLAN r


    -- отбираем чеки указанного подотдела для подсчета среднего (пицца\гор цех)
	INSERT INTO @SALE_CHECK_ON_DATE
	(
		[Date]	, 
		[SALE_CHECK_COUNT]
	)
	SELECT
			[DateDoc],
			count(*)
	 FROM
			dbo.SaleChecks sc
	INNER JOIN
			dbo.SubDepartments_SaleChecks_Link link ON link.SaleCheckId = sc.Id AND link.SubDepartmentId = @Average_SubDepartamentId
	WHERE
			sc.[PlatformId] = @PlatformId   AND
			sc.[DateDoc] BETWEEN dateadd(mm, -3, @DateEnd) AND @DateEnd
	GROUP BY
			sc.[DateDoc]
	ORDER BY
			sc.[DateDoc]


    --чеки из плана продаж для суши
	UPDATE
			@SALE_CHECK_ON_DATE
	   SET
			[SUCHI_COUNT] = (SELECT	
									rsp.[SUCHI_COUNT]
							   FROM
									@RESULT_SALE_PLAN rsp
							  WHERE 
									rsp.[Date] = scd.[Date]
							 )
	  FROM
			@SALE_CHECK_ON_DATE scd


	DECLARE @CURRENT_Date				DATETIME
	DECLARE @CURRENT_SALE_CHECK_COUNT	INT
	DECLARE @CURRENT_AVERAGE			INT	
	DECLARE @DAY_STEP					INT

   --курсор подсчета среднего за три дня для чеков
	DECLARE SALE_CHECK_ON_DATE_CURSOR CURSOR FOR   
	SELECT 
		[Date],
		[SALE_CHECK_COUNT]
	FROM 
		@SALE_CHECK_ON_DATE
	WHERE
		[Date] BETWEEN @DateBegin AND @DateEnd
    ORDER BY
		[Date]


	--считает среднее за дня дня по суши
	OPEN SALE_CHECK_ON_DATE_CURSOR  
	FETCH NEXT FROM SALE_CHECK_ON_DATE_CURSOR   
	INTO @CURRENT_Date, @CURRENT_SALE_CHECK_COUNT
  
	WHILE @@FETCH_STATUS = 0  
	BEGIN  
		SET @DAY_STEP = 10
		WHILE(@DAY_STEP <= 30)
		BEGIN

			IF ((SELECT count(*) FROM @SALE_CHECK_ON_DATE_AVERAGE) < 3)
			BEGIN
					-- отбираем ближайшие даты, сортируем по убыванию дат
					INSERT INTO @SALE_CHECK_ON_DATE_AVERAGE
					(
						[Date],
						[COUNT]
					)
					SELECT 
							[Date],
							[SALE_CHECK_COUNT]
					  FROM
							@SALE_CHECK_ON_DATE scd
					 WHERE
							scd.[Date] NOT IN (SELECT [Date] FROM @SALE_CHECK_ON_DATE_AVERAGE)  AND
							scd.[Date] BETWEEN dateadd(mm, @CONSTANT_MONTH_AVERAGE, @CURRENT_Date) AND @CURRENT_Date AND
							(scd.[SUCHI_COUNT] - @DAY_STEP) <= @CURRENT_SALE_CHECK_COUNT AND @CURRENT_SALE_CHECK_COUNT <= (scd.[SUCHI_COUNT] + @DAY_STEP)
				  ORDER BY
							[Date] DESC

			END
			
			SET @DAY_STEP = @DAY_STEP + 10
		END

		SET	@CURRENT_AVERAGE = (
									SELECT 
											SUM(t1.MIN_COUNT) / @CONSTANT_DAY_AVERAGE
									FROM
											(
												SELECT 
														top 3 [COUNT] as MIN_COUNT
												FROM
														@SALE_CHECK_ON_DATE_AVERAGE
											) t1
								)


		UPDATE 
				@RESULT_SALE_PLAN
		SET
				[AVERAGE] = @CURRENT_AVERAGE
		WHERE
				[Date] = @CURRENT_Date

        DELETE FROM @SALE_CHECK_ON_DATE_AVERAGE
	
		FETCH NEXT FROM SALE_CHECK_ON_DATE_CURSOR   
		INTO @CURRENT_Date, @CURRENT_SALE_CHECK_COUNT
	END   
	CLOSE SALE_CHECK_ON_DATE_CURSOR  
	DEALLOCATE SALE_CHECK_ON_DATE_CURSOR 
	

	INSERT INTO @RESULT
	(
		[Date],
		[COUNT]
	)		
	SELECT 
			[Date] as [Date],
			ISNULL([PIZZA_COUNT], 0) + ISNULL([AVERAGE], 0)
	  FROM 
			@RESULT_SALE_PLAN

      RETURN
END