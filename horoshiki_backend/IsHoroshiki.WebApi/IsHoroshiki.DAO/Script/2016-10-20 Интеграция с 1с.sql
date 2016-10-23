
CREATE TABLE [dbo].[IntegrationChecks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateReceive] [datetime] NOT NULL,
	[Cmd] [nvarchar](256) NULL,
	[IdCheck] [nvarchar](100) NULL,
	[DateDoc] [nvarchar](25) NULL,
	[Status] [nvarchar](100) NULL,
	[Client] [nvarchar](100) NULL,
	[Cook] [nvarchar](100) NULL,
	[Zona] [nvarchar](10) NULL,
	[Before] [nvarchar](10) NULL,
	[OrderView] [nvarchar](100) NULL,
	[PlanCookingTimeStart] [nvarchar](25) NULL,
	[PlanCookingTimeEnd] [nvarchar](25) NULL,
	[PlanCookingDateStart] [nvarchar](25) NULL,
	[PlanCookingDateEnd] [nvarchar](25) NULL,
	[TimeDelivery] [nvarchar](25) NULL,
	[DateDelivery] [nvarchar](25) NULL,
	[Driver] [nvarchar](25) NULL,
	[Address] [nvarchar](max) NULL,
	[AddressKaldr] [nvarchar](max) NULL,
	[CoordinateWidth] [nvarchar](100) NULL,
	[CoordinateLongitude] [nvarchar](100) NULL,
	[IsSushiSubDepartment] [nvarchar](10) NULL,
	[IsPizzaSubDepartment] [nvarchar](10) NULL,
	[IsCoolSubDepartment] [nvarchar](10) NULL,
	[IsSuccessConvert] [bit] NULL,
	[ErrorConvert] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.IntegrationChecks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO



CREATE TABLE [dbo].[SaleChecks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuyProcessId] [int] NULL,
	[PlatformId] [int] NOT NULL,
	[DateDoc] [datetime] NULL,
	[IdCheck] [nvarchar](100) NULL,
	[Sum] [money] NOT NULL,
	[PlanCookingStart] [datetime] NULL,
	[FactCookingStart] [datetime] NULL,
	[PlanCookingEnd] [datetime] NULL,
	[FactCookingEnd] [datetime] NULL,
	[PlanPackingStart] [datetime] NULL,
	[FactPackingStart] [datetime] NULL,
	[PlanPackingEnd] [datetime] NULL,
	[FactPackingEnd] [datetime] NULL,
	[PlanDeliveryStart] [datetime] NULL,
	[FactDeliveryStart] [datetime] NULL,
	[PlanDeliveryEnd] [datetime] NULL,
	[FactDeliveryEnd] [datetime] NULL,
 CONSTRAINT [PK_dbo.SaleChecks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SaleChecks]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SaleChecks_dbo.BuyProcesses_BuyProcessId] FOREIGN KEY([BuyProcessId])
REFERENCES [dbo].[BuyProcesses] ([Id])
GO

ALTER TABLE [dbo].[SaleChecks] CHECK CONSTRAINT [FK_dbo.SaleChecks_dbo.BuyProcesses_BuyProcessId]
GO

ALTER TABLE [dbo].[SaleChecks]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SaleChecks_dbo.Platforms_PlatformId] FOREIGN KEY([PlatformId])
REFERENCES [dbo].[Platforms] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SaleChecks] CHECK CONSTRAINT [FK_dbo.SaleChecks_dbo.Platforms_PlatformId]
GO



CREATE TABLE [dbo].[SubDepartments_SaleChecks_Link](
	[SaleCheckId] [int] NOT NULL,
	[SubDepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SubDepartments_SaleChecks_Link] PRIMARY KEY CLUSTERED 
(
	[SaleCheckId] ASC,
	[SubDepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SubDepartments_SaleChecks_Link]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SubDepartments_SaleChecks_Link_dbo.SaleChecks_SaleCheckId] FOREIGN KEY([SaleCheckId])
REFERENCES [dbo].[SaleChecks] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SubDepartments_SaleChecks_Link] CHECK CONSTRAINT [FK_dbo.SubDepartments_SaleChecks_Link_dbo.SaleChecks_SaleCheckId]
GO

ALTER TABLE [dbo].[SubDepartments_SaleChecks_Link]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SubDepartments_SaleChecks_Link_dbo.SubDepartments_SubDepartmentId] FOREIGN KEY([SubDepartmentId])
REFERENCES [dbo].[SubDepartments] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SubDepartments_SaleChecks_Link] CHECK CONSTRAINT [FK_dbo.SubDepartments_SaleChecks_Link_dbo.SubDepartments_SubDepartmentId]
GO
