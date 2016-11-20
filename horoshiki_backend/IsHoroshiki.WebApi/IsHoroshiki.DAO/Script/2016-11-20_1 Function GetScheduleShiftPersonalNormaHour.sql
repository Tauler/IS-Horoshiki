-- подсчет нормачасов для пользователя
CREATE FUNCTION [dbo].[GetScheduleShiftPersonalNormaHour]
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
	DECLARE @TimeId		  int
	DECLARE @TimeShiftPersonalScheduleId  int
	DECLARE @TimeStartTime time(7)
	DECLARE @TimeStopTime  time(7)
	
	--таблица смен для сотрудника
	DECLARE @RESULT TABLE
	(
		[Date]						datetime, 
		[ShiftPersonalScheduleId]	int,
		[ShiftTypeId]				int,
		[NormaHour]					int
	)

	--часы смен для сотрудника
	DECLARE @RESULT_SHIFT TABLE
	(
	    [Id]						int,
		[ShiftPersonalScheduleId]	int,
		[StartTime]					time(7),
		[StopTime]					time(7),
		[StopTimeCorrect]			time(7),
		[NormaHour]					int
	)

	--курсор периода дат
	DECLARE DATE_CURSOR CURSOR FOR   
	SELECT 
		[Date]
	FROM 
		[dbo].[GetDateRange]('d', @DateBegin, @DateEnd) 

	OPEN DATE_CURSOR  
	FETCH NEXT FROM DATE_CURSOR   
	INTO @CURRENT_DATE
  
	WHILE @@FETCH_STATUS = 0  
	BEGIN  

	    --отбираем все смены для сотрудника
		INSERT INTO @RESULT
		(
			[Date]					 , 
			[ShiftPersonalScheduleId],
			[ShiftTypeId] 
		)
		SELECT
			@CURRENT_DATE,
			[Id],
			[ShiftTypeId]
		FROM
			[dbo].[ShiftPersonalSchedules]
		WHERE 
			UserId = @UserId

		FETCH NEXT FROM DATE_CURSOR   
		INTO @CURRENT_DATE
	END   
	CLOSE DATE_CURSOR  
	DEALLOCATE DATE_CURSOR 

	IF (@ShiftTypeId > 0)
	BEGIN
		DELETE FROM @RESULT WHERE [ShiftTypeId] <> @ShiftTypeId
	END


	INSERT INTO @RESULT_SHIFT
	(
		[Id],
		[ShiftPersonalScheduleId],
		[StartTime]				 ,
		[StopTime]			
	)
	SELECT
		spsp.Id,
		spsp.[ShiftPersonalScheduleId],
		spsp.[StartTime],
		spsp.[StopTime]
	FROM
		[dbo].[ShiftPersonalSchedulePeriods] spsp
	INNER JOIN @RESULT r ON r.[ShiftPersonalScheduleId] = spsp.[ShiftPersonalScheduleId]

	--курсор периода дат
	DECLARE TIME_SHIFT_CURSOR CURSOR FOR   
	SELECT 
		[Id],
		[ShiftPersonalScheduleId],
		[StartTime], 
		[StopTime]
	FROM 
		@RESULT_SHIFT

	OPEN TIME_SHIFT_CURSOR  
	FETCH NEXT FROM TIME_SHIFT_CURSOR   
	INTO @TimeId, @TimeShiftPersonalScheduleId, @TimeStartTime, @TimeStopTime
  
	WHILE @@FETCH_STATUS = 0  
	BEGIN  

		UPDATE
				@RESULT_SHIFT
		   SET
				[StopTimeCorrect] = (SELECT	
											StartTime
									  FROM 
											@RESULT_SHIFT rs2
									 WHERE
											rs2.ShiftPersonalScheduleId = @TimeShiftPersonalScheduleId AND
											rs2.StartTime >= @TimeStartTime AND
											rs2.StartTime <= @TimeStopTime  AND
											rs2.Id <> @TimeId
									)
		WHERE
			 Id = @TimeId

		FETCH NEXT FROM TIME_SHIFT_CURSOR   
		INTO @TimeId, @TimeShiftPersonalScheduleId, @TimeStartTime, @TimeStopTime
	END   
	CLOSE TIME_SHIFT_CURSOR  
	DEALLOCATE TIME_SHIFT_CURSOR 

	UPDATE
			@RESULT_SHIFT
		SET
			[StopTime] = [StopTimeCorrect]
	WHERE
			[StopTimeCorrect] IS NOT NULL

	UPDATE
			@RESULT_SHIFT
	   SET
			NormaHour = (
							SELECT
							CASE
								WHEN StartTime <= StopTime THEN DATEDIFF(hour, StartTime, StopTime)
								ELSE DATEDIFF(hour, CONVERT(DATETIME, StartTime), DATEADD(day, 1, CONVERT(DATETIME, StopTime)))  
							END 	
							FROM
								@RESULT_SHIFT rs2
							WHERE
								 rs.Id = rs2.Id
						)
	  FROM
			@RESULT_SHIFT rs

	UPDATE
			@RESULT
	   SET
			NormaHour = (
							SELECT		
									SUM(ISNULL(NormaHour, 0))
							  FROM
									@RESULT_SHIFT rs
							 WHERE
									r.ShiftPersonalScheduleId = rs.ShiftPersonalScheduleId
						)
	  FROM
		    @RESULT r
	
	RETURN(SELECT SUM(ISNULL(NormaHour, 0)) FROM @RESULT)	
END