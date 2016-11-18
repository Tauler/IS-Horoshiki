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
	--статус уволен
	DECLARE @EmployeeStatusFiredGuid uniqueidentifier
	DECLARE @EmployeeStatusFiredId   int

	SET @EmployeeStatusFiredGuid = Convert(uniqueidentifier, '104688A6-9CD2-4FB9-AB03-9DA1B5474BE0')
	SET @EmployeeStatusFiredId = (SELECT Id from EmployeeStatuses WHERE Guid = @EmployeeStatusFiredGuid)

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
		[DepartmentGuid]  [uniqueidentifier],
		[DepartmentName]  nvarchar(100),
		[SubDepartmentId] int,
		[SubDepartmentGuid]	 [uniqueidentifier],
		[SubDepartmentName]  nvarchar(100),
		[UserId]		  int,
		[UserName]		  nvarchar(100),
		[PositionId]	  int,
		[PositionGuid]	  [uniqueidentifier],
		[PositionName]	  nvarchar(100),
		[ShiftPersonalScheduleId]	 int,
		[ShiftPersonalScheduleDate]  datetime,
		[ShiftTypeId]				 int,
		[ShiftTypeGuid]	  [uniqueidentifier],
		[ShiftTypeDescr]  nvarchar(25)
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
	CLOSE DATE_CURSOR  
	DEALLOCATE DATE_CURSOR 

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

	--добавляем сотрудников
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
	LEFT JOIN AspNetUsers u ON
		 u.PlatformId = @PlatformId			AND 	
		 u.DepartmentId = r.DepartmentId	AND
		 u.EmployeeStatusId <> @EmployeeStatusFiredId AND
		 ((u.SubDepartmentId IS NOT NULL AND u.SubDepartmentId = r.SubDepartmentId) OR
		 (u.SubDepartmentId IS NULL AND u.DepartmentId IS NOT NULL AND u.DepartmentId = r.DepartmentId))
		

	--добаляем смены для сотрудников
	INSERT INTO #RESULT_USER_SHIFT
	(
		[DateDoc]		  , 
		[DepartmentId]	  ,
		[SubDepartmentId] ,
		[UserId]		  ,
		[PositionId]	  ,
		[ShiftPersonalScheduleId],
		[ShiftTypeId]	  ,
		[ShiftPersonalScheduleDate]	  
	)
	SELECT
		ru.[DateDoc]		 , 
		ru.[DepartmentId]	 ,
		ru.[SubDepartmentId] ,
		ru.[UserId]			 ,
		ru.[PositionId]		 ,
		sp.Id				 ,
		sp.ShiftTypeId		 ,
		sp.Date
	FROM
		#RESULT_USER ru
	LEFT JOIN
		[dbo].[ShiftPersonalSchedules] sp ON sp.UserId = ru.UserId AND convert(varchar(10), sp.[Date], 120) = convert(varchar(10), ru.DateDoc, 120)

    -- Наименование отдела
	UPDATE
			#RESULT_USER_SHIFT
	   SET
			DepartmentName = Value,
			DepartmentGuid = [Guid]
	  FROM
			Departments
	 WHERE  
			#RESULT_USER_SHIFT.DepartmentId IS NOT NULL AND
			#RESULT_USER_SHIFT.DepartmentId = Departments.Id

	-- Наименование подотдела
	UPDATE
			#RESULT_USER_SHIFT
	   SET
			SubDepartmentName = Value,
			SubDepartmentGuid = [Guid]
	  FROM
			SubDepartments
	 WHERE  
			#RESULT_USER_SHIFT.SubDepartmentId IS NOT NULL AND
			#RESULT_USER_SHIFT.SubDepartmentId = SubDepartments.Id

	-- Наименование должности
	UPDATE
			#RESULT_USER_SHIFT
	   SET
			PositionName = Value,
			PositionGuid = Guid
	  FROM
			Positions
	 WHERE  
			#RESULT_USER_SHIFT.PositionId IS NOT NULL AND
			#RESULT_USER_SHIFT.PositionId = Positions.Id

	-- Наименование пользователя
	UPDATE
			#RESULT_USER_SHIFT
	   SET
			UserName = LastName + ' ' + FirstName
	  FROM
			AspNetUsers
	 WHERE  
			#RESULT_USER_SHIFT.UserId IS NOT NULL AND
			#RESULT_USER_SHIFT.UserId = AspNetUsers.Id

	-- Сокращенное наименование смены
	UPDATE
			#RESULT_USER_SHIFT
	   SET
			[ShiftTypeDescr] = Socr,
			[ShiftTypeGuid]  = [Guid]
	  FROM
			ShiftTypes
	 WHERE  
			#RESULT_USER_SHIFT.[ShiftTypeId] IS NOT NULL AND 
			#RESULT_USER_SHIFT.[ShiftTypeId] = ShiftTypes.Id


	SELECT 
		[DateDoc]		  , 
		[DepartmentId]	  ,
		[DepartmentGuid]  ,
		[DepartmentName]  ,
		[SubDepartmentId] ,
		[SubDepartmentGuid],
		[SubDepartmentName],
		[UserId]		  ,
		[UserName]		  ,
		[PositionId]	  ,
		[PositionGuid]	  ,
		[PositionName]	  ,
		[ShiftPersonalScheduleId],
		[ShiftPersonalScheduleDate],
		[ShiftTypeId],
		[ShiftTypeGuid],
		[ShiftTypeDescr]
	FROM 
		#RESULT_USER_SHIFT

	DROP TABLE #RESULT
	DROP TABLE #RESULT_USER
	DROP TABLE #RESULT_USER_SHIFT
END