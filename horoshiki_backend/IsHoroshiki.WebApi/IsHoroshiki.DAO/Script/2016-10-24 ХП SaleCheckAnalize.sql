USE [IsHoroshiki]
GO
/****** Object:  StoredProcedure [dbo].[SaleCheckAnalize]    Script Date: 24.10.2016 17:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SaleCheckAnalize]
(
	@PlatformId	int,
    @DateBegin	DATETIME,
    @DateEnd	DATETIME,
    @IsSuchi	bit
)
AS
BEGIN
	CREATE TABLE #RESULT
	(
		[Id]			  int,
		[IdCheck]		  nvarchar(100),
		[DateDoc]		  datetime, 
		[BuyProcessId]	  int,
		[SubDepartmentId] int,
		[IsSuchi]		  bit,
		[IsNeedRemove]	  bit
	)

	--отбираем все чеки за указанный период
	INSERT INTO #RESULT
	SELECT 
			[Id],
			[IdCheck],
			[DateDoc], 
			[BuyProcessId], 
			link.[SubDepartmentId],
			0,
			0
	  FROM [dbo].[SaleChecks] sc
	  INNER JOIN [dbo].[SubDepartments_SaleChecks_Link] link ON sc.[Id] = link.[SaleCheckId]
	 WHERE 
			[PlatformId] = @PlatformId AND
			[DateDoc] >= @DateBegin AND [DateDoc] <= @DateEnd


	-- удалем чеки с отделами не входящими в Тип чека ("Суши" или "Пицца")
	 UPDATE
			#RESULT 
		SET 
			[IsNeedRemove] = 1
	  WHERE 
			[SubDepartmentId] not in 
			(
				SELECT
						ID
				FROM
						[SubDepartments] 
				WHERE
						[GUID] in ('FCD7586F-EDDB-4531-BE83-E006BEB766D3', 'F2E916DC-21BB-47FB-8863-7ACF15DAAB02', '4A1872B9-D334-4878-A895-0E4D2E7CDA70')
			)
		
	DELETE FROM 
			#RESULT 
	WHERE 
			ID in (SELECT DISTINCT ID FROM #RESULT WHERE [IsNeedRemove] = 1)

	--Тип чека ("Суши" или "Пицца")
		--Если в списке отделов у заказа ТОЛЬКО "Цех пицца", то тип заказа "Пицца"
		--Если в списке отделов есть нижеследующие, то это - "Суши"
			--“цех суши”
			--"цех суши” + “холодный цех”
			--“цех суши” + “холодный цех” + “цех пиццы”
			--“цех суши” + “цех пиццы”
			--“холодный цех” + “цех пиццы”
	UPDATE 
			#RESULT
	   SET
			[IsSuchi] = 1
	 WHERE
 			[SubDepartmentId] in (SELECT ID FROM [SubDepartments] WHERE [GUID] = 'FCD7586F-EDDB-4531-BE83-E006BEB766D3') AND
			ID = 
			(
				SELECT	
						ID
				 FROM 
						#RESULT r2
				WHERE
						#RESULT.ID = r2.ID
				GROUP BY
						ID
				HAVING COUNT(ID) = 1
			)


	SELECT 
			[DateDoc],
			[BuyProcessId],
			count(*) as CountCheck
	FROM 
	(
		SELECT DISTINCT 
				[DateDoc],
				[BuyProcessId], 
				[Id], 
				[IsSuchi]
		FROM 
				#RESULT
	) d
	WHERE
			[IsSuchi] = @IsSuchi
	GROUP BY
			[DateDoc], [BuyProcessId]
	ORDER BY
			[DateDoc], [BuyProcessId]


	DROP TABLE #RESULT;
END
