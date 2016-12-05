DELETE FROM [dbo].[SubDepartments_SaleChecks_Link]


INSERT INTO [dbo].[SubDepartments_SaleChecks_Link]
(
	[SaleCheckId],
	[SubDepartmentId]
)
SELECT
	sc.[Id],
	(SELECT Id FROM [dbo].[SubDepartments] WHERE Guid = 'FCD7586F-EDDB-4531-BE83-E006BEB766D3')
  FROM
	dbo.IntegrationChecks ic
  INNER JOIN dbo.SaleChecks sc ON SC.IdCheck = ic.[IdCheck] 
  WHERE 
	ic.IsSushiSubDepartment = 1 and
	ic.Id = (
				SELECT 
						MAX(Id)
				  FROM
						dbo.IntegrationChecks ic2
				 WHERE
						ic2.IdCheck = ic.IdCheck  
			)


INSERT INTO [dbo].[SubDepartments_SaleChecks_Link]
(
	[SaleCheckId],
	[SubDepartmentId]
)
SELECT
	sc.[Id],
	(SELECT Id FROM [dbo].[SubDepartments] WHERE Guid = 'F2E916DC-21BB-47FB-8863-7ACF15DAAB02')
  FROM
	dbo.IntegrationChecks ic
  INNER JOIN dbo.SaleChecks sc ON SC.IdCheck = ic.[IdCheck] 
  WHERE 
	ic.[IsCoolSubDepartment] = 1 and
	ic.Id = (
				SELECT 
						MAX(Id)
				  FROM
						dbo.IntegrationChecks ic2
				 WHERE
						ic2.IdCheck = ic.IdCheck  
			)


INSERT INTO [dbo].[SubDepartments_SaleChecks_Link]
(
	[SaleCheckId],
	[SubDepartmentId]
)
SELECT
	sc.[Id],
	(SELECT Id FROM [dbo].[SubDepartments] WHERE Guid = '4A1872B9-D334-4878-A895-0E4D2E7CDA70')
  FROM
	dbo.IntegrationChecks ic
  INNER JOIN dbo.SaleChecks sc ON SC.IdCheck = ic.[IdCheck] 
  WHERE 
	ic.[IsPizzaSubDepartment] = 1 and
	ic.Id = (
				SELECT 
						MAX(Id)
				  FROM
						dbo.IntegrationChecks ic2
				 WHERE
						ic2.IdCheck = ic.IdCheck  
			)

	

