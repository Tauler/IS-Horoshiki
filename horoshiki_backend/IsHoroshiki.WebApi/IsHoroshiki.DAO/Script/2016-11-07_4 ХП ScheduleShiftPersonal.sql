CREATE PROCEDURE [dbo].[ScheduleShiftPersonal]
(
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
		[UserId]		  int
	)

	CREATE TABLE #RESULT_USER_SHIFT
	(
		[DateDoc]		  datetime, 
		[DepartmentId]	  int,
		[SubDepartmentId] int,
		[UserId]		  int,
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
		INSERT INTO  #RESULT
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


	--отбираем добавляем пользователей для сотрудников
	INSERT INTO #RESULT_USER
	(
		[DateDoc]		  , 
		[DepartmentId]	  ,
		[SubDepartmentId] ,
		[UserId]		  
	)
	SELECT
		r.[DateDoc]		    , 
		r.[DepartmentId]	,
		r.[SubDepartmentId] ,
		u.Id
	FROM
		#RESULT r
	LEFT JOIN
		AspNetUsers u ON
		 (u.SubDepartmentId IS NOT NULL AND u.SubDepartmentId = r.SubDepartmentId) OR
		 (u.SubDepartmentId IS NULL AND u.DepartmentId IS NOT NULL AND u.DepartmentId = r.DepartmentId)

	--бобаляем смены графика для сотрудников
	INSERT INTO #RESULT_USER_SHIFT
	(
		[DateDoc]		  , 
		[DepartmentId]	  ,
		[SubDepartmentId] ,
		[UserId]		  ,
		[ShiftPersonalSchedulePeriodId],
		[ShiftTypeId]		  
	)
	SELECT
		ru.[DateDoc]		 , 
		ru.[DepartmentId]	 ,
		ru.[SubDepartmentId] ,
		ru.[UserId]			 ,
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