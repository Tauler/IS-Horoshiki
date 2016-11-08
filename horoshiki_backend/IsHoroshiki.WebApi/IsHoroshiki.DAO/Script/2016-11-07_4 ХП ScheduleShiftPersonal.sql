CREATE PROCEDURE [dbo].[ScheduleShiftPersonal]
(
	@Departaments AS dbo.IdList READONLY,
	@SubDepartaments AS dbo.IdList READONLY,
	@PlatformId INT,
    @DateBegin	DATETIME,
    @DateEnd	DATETIME
)
AS
BEGIN
	DECLARE @CURRENT_DATE datetime

	CREATE TABLE #RESULT
	(
		[DateDoc]		  datetime, 
		[DepartmentId]	  int,
		[SubDepartmentId] int
	)

	CREATE TABLE #RESULT_USER
	(
		[DateDoc]		  datetime, 
		[DepartmentId]	  int,
		[SubDepartmentId] int,
		[UserId]		  int,
		[PositionId]	  int
	)

	CREATE TABLE #RESULT_USER_SHIFT
	(
		[DateDoc]		  datetime, 
		[DepartmentId]	  int,
		[SubDepartmentId] int,
		[UserId]		  int,
		[PositionId]	  int,
		[ShiftPersonalSchedulePeriodId] int,
		[ShiftTypeId] int
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

	    --отбираем все отделы\подотделы на дату
		INSERT INTO #RESULT
		(
			[DateDoc]		  , 
			[DepartmentId]	  ,
			[SubDepartmentId] 
		)
		SELECT
			@CURRENT_DATE,
			Departments.Id,
			SubDepartments.Id
		FROM
			Departments
		LEFT JOIN 
			SubDepartments ON SubDepartments.DepartmentId = Departments.Id 

		FETCH NEXT FROM DATE_CURSOR   
		INTO @CURRENT_DATE
	END   
	CLOSE DATE_CURSOR;  
	DEALLOCATE DATE_CURSOR; 

	IF ((SELECT count(*) FROM @SubDepartaments) > 0)
	BEGIN
		DELETE FROM 
			#RESULT 
		WHERE 
		    SubDepartmentId IS NOT NULL AND
			SubDepartmentId not in 
			(
				SELECT
						Id
					FROM
						@SubDepartaments
			)
	END

	IF ((SELECT count(*) FROM @Departaments) > 0)
	BEGIN
		DELETE FROM 
			#RESULT 
		WHERE 
			DepartmentId not in 
			(
				SELECT
						Id
					FROM
						@Departaments
			)
	END

	--отбираем добавляем пользователей для сотрудников
	INSERT INTO #RESULT_USER
	(
		[DateDoc]		  , 
		[DepartmentId]	  ,
		[SubDepartmentId] ,
		[UserId]		  ,
		[PositionId]
	)
	SELECT
		r.[DateDoc]		    , 
		r.[DepartmentId]	,
		r.[SubDepartmentId] ,
		u.Id,
		u.PositionId
	FROM
		#RESULT r
	LEFT JOIN
		AspNetUsers u ON
		 u.PlatformId = @PlatformId AND 	
		 ((u.SubDepartmentId IS NOT NULL AND u.SubDepartmentId = r.SubDepartmentId) OR
		 (u.SubDepartmentId IS NULL AND u.DepartmentId IS NOT NULL AND u.DepartmentId = r.DepartmentId))


	--бобаляем смены графика для сотрудников
	INSERT INTO #RESULT_USER_SHIFT
	(
		[DateDoc]		  , 
		[DepartmentId]	  ,
		[SubDepartmentId] ,
		[UserId]		  ,
		[PositionId]	  ,
		[ShiftPersonalSchedulePeriodId],
		[ShiftTypeId]		  
	)
	SELECT
		ru.[DateDoc]		 , 
		ru.[DepartmentId]	 ,
		ru.[SubDepartmentId] ,
		ru.[UserId]			 ,
		ru.[PositionId]		 ,
		spp.Id				 ,
		spp.ShiftTypeId
	FROM
		#RESULT_USER ru
	LEFT JOIN
		[dbo].[ShiftPersonalSchedules] sp ON sp.UserId = ru.UserId AND convert(varchar(10), sp.[Date], 120) = convert(varchar(10), ru.DateDoc, 120)
	LEFT JOIN
		[dbo].[ShiftPersonalSchedulePeriods] spp ON spp.[ShiftPersonalScheduleId] = sp.Id


	SELECT * FROM #RESULT_USER_SHIFT

	DROP TABLE #RESULT
	DROP TABLE #RESULT_USER
	DROP TABLE #RESULT_USER_SHIFT
END