/****** Object:  Table [dbo].[DeliveryZones]    Script Date: 13.10.2016 8:47:15 ******/
DROP TABLE [dbo].[DeliveryZones]
GO

/****** Object:  Table [dbo].[DeliveryZoneTypes]    Script Date: 13.10.2016 8:47:48 ******/
IF OBJECT_ID('dbo.DeliveryZoneTypes', 'U') IS NOT NULL DROP TABLE [dbo].[DeliveryZoneTypes]
GO

CREATE TABLE [dbo].[DeliveryZones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlatformId] [int] NOT NULL,
	[DeliveryZoneTypeId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Coordinates] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_dbo.DeliveryZones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[DeliveryZoneTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[Time] [int] NOT NULL,
	[Background] [nvarchar](10) NOT NULL,
	[Opacity] [real] NOT NULL,
	[BorderColor] [nvarchar](10) NOT NULL,
	[Value] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_dbo.DeliveryZoneTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[DeliveryZones]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DeliveryZones_dbo.DeliveryZoneTypes_DeliveryZoneTypeId] FOREIGN KEY([DeliveryZoneTypeId])
REFERENCES [dbo].[DeliveryZoneTypes] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DeliveryZones] CHECK CONSTRAINT [FK_dbo.DeliveryZones_dbo.DeliveryZoneTypes_DeliveryZoneTypeId]
GO

ALTER TABLE [dbo].[DeliveryZones]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DeliveryZones_dbo.Platforms_PlatformId] FOREIGN KEY([PlatformId])
REFERENCES [dbo].[Platforms] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DeliveryZones] CHECK CONSTRAINT [FK_dbo.DeliveryZones_dbo.Platforms_PlatformId]
GO

INSERT INTO [dbo].[DeliveryZoneTypes] ([Guid],[Value], [Time], [Background], [Opacity], [BorderColor]) VALUES ('48922505-A864-400D-B3D0-F4F70DDEB1E6', 'Çîíà 1', 0, '#FF0000', 1, '#918383')
GO

INSERT INTO [dbo].[DeliveryZoneTypes] ([Guid],[Value], [Time], [Background], [Opacity], [BorderColor]) VALUES ('B5874A2C-2711-42CC-B88A-54E8259FE7EC', 'Çîíà 2', 0, '#FF8000', 1, '#918383')
GO

INSERT INTO [dbo].[DeliveryZoneTypes] ([Guid],[Value], [Time], [Background], [Opacity], [BorderColor]) VALUES ('FC8EDEDC-BAB1-42BA-A8CA-448657B7D05F', 'Çîíà 3', 0, '#FFFF00', 1, '#918383')
GO

INSERT INTO [dbo].[DeliveryZoneTypes] ([Guid],[Value], [Time], [Background], [Opacity], [BorderColor]) VALUES ('66BC1D1D-8B35-491D-A57F-CB5A4574295B', 'Çîíà 4', 0, '#80FF00', 1, '#918383')
GO