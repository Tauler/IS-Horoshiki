CREATE TABLE [dbo].[PlanTypes](
	[Id]	[int] IDENTITY(1,1) NOT NULL,
	[Guid]	[uniqueidentifier]	NOT NULL,
	[Value] [nvarchar](100)		NOT NULL,
 CONSTRAINT [PK_dbo.PlanTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


INSERT INTO [dbo].[PlanTypes] ([Guid],[Value]) VALUES ('D4C8C9C0-EA2F-47B6-8156-3030153AB8F4', '����');

INSERT INTO [dbo].[PlanTypes] ([Guid],[Value]) VALUES ('5DE8DA4E-8E06-47B9-975E-354BAF1D41CE', '�����');

ALTER TABLE [dbo].[SalePlans]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SalePlans_dbo.PlanTypes_PlanTypeId] FOREIGN KEY([PlanTypeId])
REFERENCES [dbo].[PlanTypes] ([Id])
ON DELETE CASCADE
