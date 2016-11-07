ALTER PROCEDURE [dbo].[ScheduleShiftPersonal]
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

	DECLARE DATE_CURSOR CURSOR FOR   
	SELECT dateadd(day, number, @DateBegin)
	FROM 
		(SELECT DISTINCT number FROM master.dbo.spt_values WHERE name is null) n
	WHERE dateadd(day, number, @DateBegin) < @DateEnd
  
	OPEN DATE_CURSOR  
	FETCH NEXT FROM DATE_CURSOR   
	INTO @CURRENT_DATE
  
	WHILE @@FETCH_STATUS = 0  
	BEGIN  

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

	

	SELECT * FROM #RESULT_USER

	DROP TABLE #RESULT
	DROP TABLE #RESULT_USER
END