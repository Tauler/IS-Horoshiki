ALTER TABLE [dbo].[Platforms] ADD [IsAroundClock] BIT NULL
GO
UPDATE [dbo].[Platforms] SET [IsAroundClock] = 0
GO
ALTER TABLE [dbo].[Platforms] ALTER COLUMN [IsAroundClock] BIT NOT NULL
GO
