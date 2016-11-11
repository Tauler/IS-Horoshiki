ALTER TABLE [dbo].[AspNetUsers] ADD [SubDepartmentId] INT NULL

GO

ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUsers_dbo.SubDepartments_SubDepartmentId] FOREIGN KEY([SubDepartmentId])
REFERENCES [dbo].[SubDepartments] ([Id])
GO

ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_dbo.AspNetUsers_dbo.SubDepartments_SubDepartmentId]
GO



