CREATE PROCEDURE [dbo].[SaleCheckAnalize]
(
	@PlatformId	int,
    @DateBegin	DATETIME,
    @DateEnd	DATETIME,
    @IsSuchi	bit
)
AS
BEGIN
	DECLARE @SubDepartmentSuchiId int
	DECLARE @DeliveryId int
	DECLARE @SelfId		int

	SET @SubDepartmentSuchiId = (SELECT ID FROM [dbo].[SubDepartments] WHERE [GUID] = 'FCD7586F-EDDB-4531-BE83-E006BEB766D3')
	SET @DeliveryId = (SELECT ID FROM [dbo].[BuyProcesses] WHERE [GUID] = 'FBBAE261-CD71-4FA3-AF63-E04FC1E5CB18')
	SET @SelfId = (SELECT ID FROM [dbo].[BuyProcesses] WHERE [GUID] = '1C47B31F-D28B-4DEF-BE40-E588CADD853B')


	CREATE TABLE #RESULT
	(
		[Id]			  int,
		[IdCheck]		  nvarchar(100),
		[DateDoc]		  datetime, 
		[BuyProcessId]	  int,
		[SubDepartmentId] int,
		[IsSuchi]		  bit,
		[IsNeedRemove]	  bit,
		[Delivery]		  int,
		[Self]			  int
	)

	--�������� ��� ���� �� ��������� ������
	INSERT INTO #RESULT
	SELECT 
			[Id],
			[IdCheck],
			[DateDoc], 
			[BuyProcessId], 
			link.[SubDepartmentId],
			0,
			0,
			0,
			0
	  FROM [dbo].[SaleChecks] sc
	  INNER JOIN [dbo].[SubDepartments_SaleChecks_Link] link ON sc.[Id] = link.[SaleCheckId]
	 WHERE 
			[PlatformId] = @PlatformId AND
			[DateDoc] >= @DateBegin AND [DateDoc] <= @DateEnd


	-- ������ ���� � �������� �� ��������� � ��� ���� ("����" ��� "�����")
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

	--��� ���� ("����" ��� "�����")
		--���� � ������ ������� � ������ ������ "��� �����", �� ��� ������ "�����"
		--���� � ������ ������� ���� �������������, �� ��� - "����"
			--���� ����
			--"��� ���� + ��������� ����
			--���� ���� + ��������� ���� + ���� ������
			--���� ���� + ���� ������
			--��������� ���� + ���� ������
	UPDATE 
			#RESULT
	   SET
			[IsSuchi] = 1
	 WHERE
 			[SubDepartmentId] = @SubDepartmentSuchiId AND
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

	--������� �� �������������� �������
	DELETE FROM #RESULT WHERE [IsSuchi] <> @IsSuchi


    --����������� ��� �������� ����� �������� ��������
	UPDATE
			#RESULT
	   SET
			[Delivery] = 1
	 WHERE
			[BuyProcessId] = @DeliveryId

	--����������� ��� �������� ����� �������� ���������
	UPDATE
			#RESULT
	   SET
			[Self] = 1
	 WHERE
			[BuyProcessId] = @SelfId


	SELECT 
			[DateDoc],
			SUM([Delivery]) as [Delivery],
			SUM([Self]) as [Self]
	FROM 
			#RESULT
	GROUP BY
			[DateDoc]
	ORDER BY
			[DateDoc]


	DROP TABLE #RESULT;
END
