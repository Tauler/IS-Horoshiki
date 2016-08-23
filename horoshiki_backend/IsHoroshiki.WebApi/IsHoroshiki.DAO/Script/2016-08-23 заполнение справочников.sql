INSERT INTO [dbo].[Positions] ([Value]) VALUES ('Операционный директор');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('Управляющий рестораном');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('Менеджер смены');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('Администратор');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('Повар сушист');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('Повар - универсал');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('Пиццер');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('Повар холодного цеха');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('Упаковщик');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('Курьер');
GO



INSERT INTO [dbo].[Departments] ([Value]) VALUES ('Колл-центр')
GO

INSERT INTO [dbo].[Departments] ([Value]) VALUES ('Администрация')
GO

INSERT INTO [dbo].[Departments] ([Value]) VALUES ('Производство')
GO

INSERT INTO [dbo].[Departments] ([Value]) VALUES ('Доставка')
GO



INSERT INTO [dbo].[SubDepartments] ([DepartmentId] ,[Value]) VALUES (3, 'Заготовительный цех')
GO

INSERT INTO [dbo].[SubDepartments] ([DepartmentId] ,[Value]) VALUES (3, 'Цех суши')
GO

INSERT INTO [dbo].[SubDepartments] ([DepartmentId] ,[Value]) VALUES (3, 'Холодный цех')
GO

INSERT INTO [dbo].[SubDepartments] ([DepartmentId] ,[Value]) VALUES (3, 'Цех пиццы')
GO

INSERT INTO [dbo].[SubDepartments] ([DepartmentId] ,[Value]) VALUES (3, 'Упаковка')
GO

INSERT INTO [dbo].[SubDepartments] ([DepartmentId] ,[Value]) VALUES (3, 'Уборка')
GO




INSERT INTO [dbo].[StatusSites] ([Value]) VALUES ('Не работает')
GO

INSERT INTO [dbo].[StatusSites] ([Value]) VALUES ('Работает')
GO

INSERT INTO [dbo].[StatusSites] ([Value]) VALUES ('Готовится к открытию')
GO


INSERT INTO [dbo].[PriceTypes] ([Value]) VALUES ('Омск')
GO

INSERT INTO [dbo].[PriceTypes] ([Value]) VALUES ('Москва')
GO

INSERT INTO [dbo].[PriceTypes] ([Value]) VALUES ('Санкт-Петербург')
GO



INSERT INTO [dbo].[DeliveryZones] ([Value], [Time]) VALUES ('Зона 1', 0)
GO

INSERT INTO [dbo].[DeliveryZones] ([Value], [Time]) VALUES ('Зона 2', 0)
GO

INSERT INTO [dbo].[DeliveryZones] ([Value], [Time]) VALUES ('Зона 3', 0)
GO

INSERT INTO [dbo].[DeliveryZones] ([Value], [Time]) VALUES ('Зона 4', 0)
GO



INSERT INTO [dbo].[EmployeeStatuses] ([Value]) VALUES  ('Стажер')
GO

INSERT INTO [dbo].[EmployeeStatuses] ([Value]) VALUES  ('Работает')
GO

INSERT INTO [dbo].[EmployeeStatuses] ([Value]) VALUES  ('Отпуск')
GO

INSERT INTO [dbo].[EmployeeStatuses] ([Value]) VALUES  ('Уволен')
GO
