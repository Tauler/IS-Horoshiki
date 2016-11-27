-- ������� ���������� ��� ������������
ALTER FUNCTION [dbo].[GetScheduleShiftPersonalNormaHour]
(
	@UserId			INT,
	@ShiftTypeId	INT,
    @DateBegin		DATETIME,
    @DateEnd		DATETIME
)
RETURNS int
AS 
BEGIN
	DECLARE @CURRENT_DATE datetime
	DECLARE @TimeStartTime datetime
	DECLARE @TimeStopTime datetime

	DECLARE @MinStartTime datetime
	DECLARE @MinStopTime  datetime

	DECLARE @SUM_NORMA_HOUR_RESULT int
	DECLARE @NORMA_HOUR_RESULT int

	--������� ���� ��� ����������
	DECLARE @RESULT TABLE
	(
		[Id]			int,
		[Date]			datetime, 
		[ShiftTypeId]	int
	)

	--���� ���� ��� ����������
	DECLARE @RESULT_SHIFT TABLE
	(
		[ShiftPersonalScheduleId]   int,
		[Date]						datetime,
		[StartTime]					datetime,
		[StopTime]					datetime
	)

	--���� ���� ��� ���������� ��� �����������
	DECLARE @RESULT_SHIFT_RESULT TABLE
	(
		[Date]		datetime,
		[StartTime]	datetime,
		[StopTime]	datetime,
		[NormaHour]	int
	)

	INSERT INTO @RESULT
	(
		[Id]	,
		[Date]	, 
		[ShiftTypeId] 
	)
	SELECT
		[Id]	,
		[Date]	,
		[ShiftTypeId]
	FROM
		[dbo].[ShiftPersonalSchedules]
	WHERE 
		UserId = @UserId AND
		Date BETWEEN @DateBegin AND @DateEnd
	
	IF (@ShiftTypeId > 0)
	BEGIN
		DELETE FROM @RESULT WHERE [ShiftTypeId] <> @ShiftTypeId
	END


	-- �������� ���� ��� ���� ����
	INSERT INTO @RESULT_SHIFT
	(
		[Date],
		[ShiftPersonalScheduleId],
		[StartTime]				 ,
		[StopTime]			
	)
	SELECT
		r.Date,
		spsp.[ShiftPersonalScheduleId],
		CONVERT(DATETIME, spsp.[StartTime]),
		CASE
			WHEN spsp.[StartTime] <= spsp.[StopTime] THEN CONVERT(DATETIME, spsp.[StopTime])
			ELSE DATEADD(day, 1, CONVERT(DATETIME, spsp.[StopTime]))  
		END		
	FROM
		[dbo].[ShiftPersonalSchedulePeriods] spsp
	INNER JOIN @RESULT r ON r.[Id] = spsp.[ShiftPersonalScheduleId]

	--������ ������� ��� ��� �������� �������������� �����
	DECLARE TIME_SHIFT_CURSOR CURSOR FOR   
	SELECT 
		[Date],
		[StartTime], 
		[StopTime]
	FROM 
		@RESULT_SHIFT
   ORDER BY
		[Date],
		[StartTime]	


	OPEN TIME_SHIFT_CURSOR  
	FETCH NEXT FROM TIME_SHIFT_CURSOR   
	INTO @CURRENT_DATE, @TimeStartTime, @TimeStopTime
  
	WHILE @@FETCH_STATUS = 0  
	BEGIN  
		-- ���� �� ���������� ������ ������� ��� ������ ������ � ������� ������
		IF (NOT EXISTS (SELECT 
								[DATE] 
						  FROM 
								@RESULT_SHIFT_RESULT 
						 WHERE 
								[DATE]			=  @CURRENT_DATE	AND
								[StartTime]		<= @TimeStopTime	AND
								[StopTime]		>= @TimeStartTime
						)
			)
		BEGIN
			INSERT INTO 
						@RESULT_SHIFT_RESULT
				 SELECT
						@CURRENT_DATE, 
						@TimeStartTime, 
						@TimeStopTime,
						DATEDIFF(minute, @TimeStartTime, @TimeStopTime)
		END
		ELSE
		BEGIN
			-- ���� ������ ������� ������ � ��������, ����������  
			-- ��� ������ ��������� ���������� ��������� ����������� ���������
			SET @MinStartTime = ISNULL((SELECT
											MAX(StopTime) 
									   FROM 
											@RESULT_SHIFT_RESULT 
									  WHERE
											[DATE]			=  @CURRENT_DATE	AND
											@TimeStartTime  >= [StartTime]		AND
											@TimeStartTime	<= [StopTime]
									  ), @TimeStartTime)


			-- ���� ��������� ������� ������ � ��������, ����������  
			-- ��� ��������� ��������� ���������� ������ ���������� ���������
			SET @MinStopTime = ISNULL((SELECT
											MIN(StartTime) 
									   FROM 
											@RESULT_SHIFT_RESULT 
									  WHERE
											[DATE]			=  @CURRENT_DATE	AND
											StartTime		>= @TimeStopTime	AND
											@TimeStopTime	<= StopTime
									  ), @TimeStopTime)

			IF (@MinStartTime < @MinStopTime)
			BEGIN
				INSERT INTO 
							@RESULT_SHIFT_RESULT
					 SELECT
							@CURRENT_DATE, 
							@MinStartTime, 
							@MinStopTime ,
							DATEDIFF(minute, @MinStartTime, @MinStopTime)
			END
		END


		FETCH NEXT FROM TIME_SHIFT_CURSOR   
		INTO @CURRENT_DATE, @TimeStartTime, @TimeStopTime
	END   
	CLOSE TIME_SHIFT_CURSOR  
	DEALLOCATE TIME_SHIFT_CURSOR 

	SET @SUM_NORMA_HOUR_RESULT = (SELECT SUM(ISNULL(NormaHour, 0)) FROM @RESULT_SHIFT_RESULT)
	SET @NORMA_HOUR_RESULT = @SUM_NORMA_HOUR_RESULT / 60;

	--����� ���� ��������� �� ��������
	IF ((@SUM_NORMA_HOUR_RESULT % 60) > 0)
	BEGIN
		SET @NORMA_HOUR_RESULT = @NORMA_HOUR_RESULT + 1
	END

	RETURN(@NORMA_HOUR_RESULT)
END