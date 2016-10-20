CREATE TABLE [dbo].[IntegrationChecks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateReceive] [datetime] NOT NULL,
	[Cmd] [nvarchar](256) NULL,
	[IdCheck] [nvarchar](100) NULL,
	[DateDoc] [nvarchar](25) NULL,
	[Status] [nvarchar](100) NULL,
	[Klient] [nvarchar](100) NULL,
	[Cook] [nvarchar](100) NULL,
	[Zona] [nvarchar](10) NULL,
	[Before] [nvarchar](10) NULL,
	[OrderView] [nvarchar](100) NULL,
	[TimeStartCooking] [nvarchar](25) NULL,
	[TimeEndCooking] [nvarchar](25) NULL,
	[DateStartMaking] [nvarchar](25) NULL,
	[DateEndMaking] [nvarchar](25) NULL,
	[TimeDelivery] [nvarchar](25) NULL,
	[DateDelivery] [nvarchar](25) NULL,
	[Driver] [nvarchar](25) NULL,
	[Address] [nvarchar](max) NULL,
	[AddressKaldr] [nvarchar](max) NULL,
	[CoordinateWidth] [nvarchar](100) NULL,
	[CoordinateLongitude] [nvarchar](100) NULL,
	[IsSushiDepartment] [nvarchar](10) NULL,
	[IsPizzaDepartment] [nvarchar](10) NULL,
	[IsCoolDepartment] [nvarchar](10) NULL,
 CONSTRAINT [PK_dbo.IntegrationChecks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]