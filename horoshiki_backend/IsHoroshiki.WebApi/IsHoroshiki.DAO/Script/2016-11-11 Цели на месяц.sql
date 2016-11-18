CREATE TABLE [dbo].[MonthObjectives](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlatformId] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[Month] [int] NOT NULL,
	[ChecksPerHourForPositionSushiChef] [float] NOT NULL,
	[ChecksPerHourForPositionCourier] [float] NOT NULL,
	[ChecksPerHourForPositionPizzaChef] [float] NOT NULL,
 CONSTRAINT [PK_MonthObjectives] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[MonthObjectives]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MonthObjectives_dbo.Platforms_PlatformId] FOREIGN KEY([PlatformId])
REFERENCES [dbo].[Platforms] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[MonthObjectives] CHECK CONSTRAINT [FK_dbo.MonthObjectives_dbo.Platforms_PlatformId]
GO