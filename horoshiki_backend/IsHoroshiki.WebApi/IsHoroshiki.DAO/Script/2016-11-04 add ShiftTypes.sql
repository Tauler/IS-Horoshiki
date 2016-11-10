CREATE TABLE [dbo].[ShiftTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[Socr] [nvarchar](25) NOT NULL,
	[Value] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_dbo.ShiftTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

go

INSERT INTO [dbo].[ShiftTypes] ([Guid],[Socr],[Value]) VALUES ('292EF8FB-49DC-42B1-9E75-BEE16D5454B4', 'У', 'Утро')
INSERT INTO [dbo].[ShiftTypes] ([Guid],[Socr],[Value]) VALUES ('4801812F-B7F1-4D64-BA8E-0E128EF3BE20', 'В', 'Вечер')
INSERT INTO [dbo].[ShiftTypes] ([Guid],[Socr],[Value]) VALUES ('435A9E46-279A-4AAB-B8A3-4412C9631BBB', 'Н', 'Ночь')
INSERT INTO [dbo].[ShiftTypes] ([Guid],[Socr],[Value]) VALUES ('9849AEF4-3413-4E3E-A427-4722CFA172F6', 'Ус', 'Усиление')