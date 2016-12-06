-- ���� ������ ��� ���������� ���� �����������
CREATE FUNCTION [dbo].[GetSalePlanForScheduleShift]
(     
     @PlatformId		int,
	 @DepartamentId		int,	--�����, �� �������� ����������� ���� ������
	 @SubDepartamentId	int,    --��������, �� �������� ����������� ���� ������
	 @DateBegin			DATETIME,
	 @DateEnd			DATETIME
)
RETURNS  
@RESULT TABLE
(
	[Date]	DATETIME,
	[COUNT]	INT
)
AS 
BEGIN
	
	DECLARE @RESULT_SALE_PLAN TABLE
	(
		[Date]	DATETIME,
		[COUNT]	int
	)

	--������������� ��� ��������
	--������� ����� + �����
	IF (@DepartamentId = 2 OR @SubDepartamentId = 5)
	BEGIN
		--������ ��� ��������
		INSERT INTO @RESULT_SALE_PLAN
		(
			[Date]
		)
		SELECT 
			[Date]
		FROM 
			[dbo].[GetDateRange]('d', @DateBegin, @DateEnd) 


		
		UPDATE
				@RESULT_SALE_PLAN
		SET
				[COUNT] =  (
								SELECT		
										SUM(ISNULL(spd.Delivery, 0) + ISNULL(spd.Self, 0))
								FROM		
										dbo.SalePlanDays spd
								INNER JOIN dbo.SalePlans sp ON sp.PlatformId = @PlatformId AND sp.Id = spd.SalePlanId
								WHERE
										spd.[Date] = r.[Date]
								)
		 FROM
				@RESULT_SALE_PLAN r
	END
	ELSE 
	--��� �����
	IF (@SubDepartamentId = 4)
	BEGIN
		INSERT INTO @RESULT_SALE_PLAN
		(
			[Date],
			[COUNT]
		) 
		SELECT 
			[Date],
			[COUNT]
		FROM 
			dbo.[GetSalePlanAverageForScheduleShift] (1, 3, 2, @DateBegin, @DateEnd)
	END
	ELSE 
	--������� ��� 
	IF (@SubDepartamentId = 3)
	BEGIN
		INSERT INTO @RESULT_SALE_PLAN
		(
			[Date],
			[COUNT]
		) 
		SELECT 
			[Date],
			[COUNT]
		FROM 
			dbo.[GetSalePlanAverageForScheduleShift] (1, 3, 2, @DateBegin, @DateEnd)
	END
	ELSE 
	--���� � ��� ���������
	--������� ���� + �����
	IF (@SubDepartamentId = 2)
	BEGIN
		--������ ��� ��������
		INSERT INTO @RESULT_SALE_PLAN
		(
			[Date]
		)
		SELECT 
			[Date]
		FROM 
			[dbo].[GetDateRange]('d', @DateBegin, @DateEnd) 


	    DECLARE @CONSTANT_Suchi_PlanTypeId INT
		SET @CONSTANT_Suchi_PlanTypeId = (SELECT id FROM dbo.PlanTypes WHERE Guid = 'D4C8C9C0-EA2F-47B6-8156-3030153AB8F4')

		UPDATE
				@RESULT_SALE_PLAN
		SET
				[COUNT] =  (
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
	END
	
	INSERT INTO @RESULT
	(
		[Date],
		[COUNT]
	)		
	SELECT 
			[Date],
			[COUNT]
	  FROM 
			@RESULT_SALE_PLAN

     RETURN
END