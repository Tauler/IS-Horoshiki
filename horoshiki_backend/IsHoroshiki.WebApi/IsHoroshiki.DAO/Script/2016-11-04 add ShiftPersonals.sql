CREATE TABLE [dbo].[ShiftPersonals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PositionId] [int] NOT NULL,
	[ShiftTypeId] [int] NOT NULL,
	[IsAroundClock] [bit] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[StopTime] [time](7) NOT NULL,
 CONSTRAINT [PK_dbo.ShiftPersonals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ShiftPersonals]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ShiftPersonals_dbo.Positions_PositionId] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ShiftPersonals] CHECK CONSTRAINT [FK_dbo.ShiftPersonals_dbo.Positions_PositionId]
GO

ALTER TABLE [dbo].[ShiftPersonals]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ShiftPersonals_dbo.ShiftTypes_ShiftTypeId] FOREIGN KEY([ShiftTypeId])
REFERENCES [dbo].[ShiftTypes] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ShiftPersonals] CHECK CONSTRAINT [FK_dbo.ShiftPersonals_dbo.ShiftTypes_ShiftTypeId]
GO