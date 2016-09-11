USE [IsHoroshiki]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](256) NOT NULL,
	[MiddleName] [nvarchar](256) NULL,
	[LastName] [nvarchar](256) NOT NULL,
	[Phone] [nvarchar](25) NULL,
	[IsHaveMedicalBook] [bit] NOT NULL,
	[MedicalBookEnd] [datetime] NULL,
	[EmployeeStatusId] [int] NOT NULL,
	[PositionId] [int] NOT NULL,
	[PlatformId] [int] NULL,
	[DateStart] [datetime] NOT NULL,
	[DateEnd] [datetime] NULL,
	[IsAccess] [bit] NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BuyProcesses]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuyProcesses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.BuyProcesses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeliveryTimes]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryTimes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.DeliveryTimes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeliveryZones]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryZones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [int] NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.DeliveryZones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeReasonDismissals]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeReasonDismissals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.EmployeeReasonDismissals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeStatuses]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.EmployeeStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderPays]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderPays](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.OrderPays] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderStatuses]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.OrderStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Platform_BuyProcess_Link]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Platform_BuyProcess_Link](
	[PlatformId] [int] NOT NULL,
	[BuyProcessId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Platform_BuyProcess_Link] PRIMARY KEY CLUSTERED 
(
	[PlatformId] ASC,
	[BuyProcessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Platforms]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Platforms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[SubDivisionId] [int] NOT NULL,
	[UserId] [int] NULL,
	[PlatformStatusId] [int] NOT NULL,
	[YandexMap] [nvarchar](1000) NULL,
	[Address] [nvarchar](250) NULL,
	[TimeStart] [time](7) NOT NULL,
	[TimeEnd] [time](7) NOT NULL,
	[MinCheck] [money] NOT NULL,
 CONSTRAINT [PK_dbo.Platforms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlatformStatuses]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlatformStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.PlatformStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Positions]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.Positions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PriceTypes]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.PriceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubDepartments]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubDepartments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.SubDepartments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubDivisions]    Script Date: 11.09.2016 15:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubDivisions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Timezone] [int] NOT NULL,
	[PriceTypeId] [int] NOT NULL,
	[SiteHeader] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.SubDivisions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 11.09.2016 15:12:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 11.09.2016 15:12:31 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 11.09.2016 15:12:31 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleId]    Script Date: 11.09.2016 15:12:31 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 11.09.2016 15:12:31 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeStatusId]    Script Date: 11.09.2016 15:12:31 ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeStatusId] ON [dbo].[AspNetUsers]
(
	[EmployeeStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlatformId]    Script Date: 11.09.2016 15:12:31 ******/
CREATE NONCLUSTERED INDEX [IX_PlatformId] ON [dbo].[AspNetUsers]
(
	[PlatformId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PositionId]    Script Date: 11.09.2016 15:12:31 ******/
CREATE NONCLUSTERED INDEX [IX_PositionId] ON [dbo].[AspNetUsers]
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 11.09.2016 15:12:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BuyProcessId]    Script Date: 11.09.2016 15:12:31 ******/
CREATE NONCLUSTERED INDEX [IX_BuyProcessId] ON [dbo].[Platform_BuyProcess_Link]
(
	[BuyProcessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlatformId]    Script Date: 11.09.2016 15:12:31 ******/
CREATE NONCLUSTERED INDEX [IX_PlatformId] ON [dbo].[Platform_BuyProcess_Link]
(
	[PlatformId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlatformStatusId]    Script Date: 11.09.2016 15:12:31 ******/
CREATE NONCLUSTERED INDEX [IX_PlatformStatusId] ON [dbo].[Platforms]
(
	[PlatformStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubDivisionId]    Script Date: 11.09.2016 15:12:31 ******/
CREATE NONCLUSTERED INDEX [IX_SubDivisionId] ON [dbo].[Platforms]
(
	[SubDivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 11.09.2016 15:12:31 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Platforms]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentId]    Script Date: 11.09.2016 15:12:31 ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[SubDepartments]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PriceTypeId]    Script Date: 11.09.2016 15:12:31 ******/
CREATE NONCLUSTERED INDEX [IX_PriceTypeId] ON [dbo].[SubDivisions]
(
	[PriceTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUsers_dbo.EmployeeStatuses_EmployeeStatusId] FOREIGN KEY([EmployeeStatusId])
REFERENCES [dbo].[EmployeeStatuses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_dbo.AspNetUsers_dbo.EmployeeStatuses_EmployeeStatusId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUsers_dbo.Platforms_PlatformId] FOREIGN KEY([PlatformId])
REFERENCES [dbo].[Platforms] ([Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_dbo.AspNetUsers_dbo.Platforms_PlatformId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUsers_dbo.Positions_PositionId] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_dbo.AspNetUsers_dbo.Positions_PositionId]
GO
ALTER TABLE [dbo].[Platform_BuyProcess_Link]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Platform_BuyProcess_Link_dbo.BuyProcesses_BuyProcessId] FOREIGN KEY([BuyProcessId])
REFERENCES [dbo].[BuyProcesses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Platform_BuyProcess_Link] CHECK CONSTRAINT [FK_dbo.Platform_BuyProcess_Link_dbo.BuyProcesses_BuyProcessId]
GO
ALTER TABLE [dbo].[Platform_BuyProcess_Link]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Platform_BuyProcess_Link_dbo.Platforms_PlatformId] FOREIGN KEY([PlatformId])
REFERENCES [dbo].[Platforms] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Platform_BuyProcess_Link] CHECK CONSTRAINT [FK_dbo.Platform_BuyProcess_Link_dbo.Platforms_PlatformId]
GO
ALTER TABLE [dbo].[Platforms]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Platforms_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Platforms] CHECK CONSTRAINT [FK_dbo.Platforms_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Platforms]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Platforms_dbo.PlatformStatuses_PlatformStatusId] FOREIGN KEY([PlatformStatusId])
REFERENCES [dbo].[PlatformStatuses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Platforms] CHECK CONSTRAINT [FK_dbo.Platforms_dbo.PlatformStatuses_PlatformStatusId]
GO
ALTER TABLE [dbo].[Platforms]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Platforms_dbo.SubDivisions_SubDivisionId] FOREIGN KEY([SubDivisionId])
REFERENCES [dbo].[SubDivisions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Platforms] CHECK CONSTRAINT [FK_dbo.Platforms_dbo.SubDivisions_SubDivisionId]
GO
ALTER TABLE [dbo].[SubDepartments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SubDepartments_dbo.Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubDepartments] CHECK CONSTRAINT [FK_dbo.SubDepartments_dbo.Departments_DepartmentId]
GO
ALTER TABLE [dbo].[SubDivisions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SubDivisions_dbo.PriceTypes_PriceTypeId] FOREIGN KEY([PriceTypeId])
REFERENCES [dbo].[PriceTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubDivisions] CHECK CONSTRAINT [FK_dbo.SubDivisions_dbo.PriceTypes_PriceTypeId]
GO
USE [master]
GO
ALTER DATABASE [IsHoroshiki] SET  READ_WRITE 
GO
