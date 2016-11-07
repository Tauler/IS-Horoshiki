CREATE TABLE [dbo].[ShiftPersonalSchedules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ShiftPersonalSchedules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ShiftPersonalSchedules]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ShiftPersonalSchedules_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ShiftPersonalSchedules] CHECK CONSTRAINT [FK_dbo.ShiftPersonalSchedules_dbo.AspNetUsers_UserId]
GO


CREATE TABLE [dbo].[ShiftPersonalSchedulePeriods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShiftPersonalScheduleId] [int] NOT NULL,
	[ShiftTypeId] [int] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[StopTime] [time](7) NOT NULL,
 CONSTRAINT [PK_dbo.ShiftPersonalSchedulePeriods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ShiftPersonalSchedulePeriods]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ShiftPersonalSchedulePeriods_dbo.ShiftPersonalSchedules_ShiftPersonalScheduleId] FOREIGN KEY([ShiftPersonalScheduleId])
REFERENCES [dbo].[ShiftPersonalSchedules] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ShiftPersonalSchedulePeriods] CHECK CONSTRAINT [FK_dbo.ShiftPersonalSchedulePeriods_dbo.ShiftPersonalSchedules_ShiftPersonalScheduleId]
GO

ALTER TABLE [dbo].[ShiftPersonalSchedulePeriods]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ShiftPersonalSchedulePeriods_dbo.ShiftTypes_ShiftTypeId] FOREIGN KEY([ShiftTypeId])
REFERENCES [dbo].[ShiftTypes] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ShiftPersonalSchedulePeriods] CHECK CONSTRAINT [FK_dbo.ShiftPersonalSchedulePeriods_dbo.ShiftTypes_ShiftTypeId]
GO