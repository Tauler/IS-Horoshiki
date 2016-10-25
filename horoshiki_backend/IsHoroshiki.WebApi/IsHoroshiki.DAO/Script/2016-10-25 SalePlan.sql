CREATE TABLE [dbo].[SalePlans](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlatformId] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[Month] [int] NOT NULL,
	[AverageCheck] [money] NOT NULL,
 CONSTRAINT [PK_dbo.SalePlans] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SalePlans]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SalePlans_dbo.Platforms_PlatformId] FOREIGN KEY([PlatformId])
REFERENCES [dbo].[Platforms] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SalePlans] CHECK CONSTRAINT [FK_dbo.SalePlans_dbo.Platforms_PlatformId]
GO


CREATE TABLE [dbo].[SalePlanDays](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SalePlanId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Delivery] [int] NOT NULL,
	[Self] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SalePlanDays] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SalePlanDays]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SalePlanDays_dbo.SalePlans_SalePlanId] FOREIGN KEY([SalePlanId])
REFERENCES [dbo].[SalePlans] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SalePlanDays] CHECK CONSTRAINT [FK_dbo.SalePlanDays_dbo.SalePlans_SalePlanId]
GO


