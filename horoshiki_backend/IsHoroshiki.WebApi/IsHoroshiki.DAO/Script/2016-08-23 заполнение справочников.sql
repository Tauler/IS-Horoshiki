INSERT INTO [dbo].[BuyProcesses] ([Value]) VALUES ('Доставка');
GO

INSERT INTO [dbo].[BuyProcesses] ([Value]) VALUES ('Самовывоз');
GO

INSERT INTO [dbo].[BuyProcesses] ([Value]) VALUES ('Ресторан');
GO


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




INSERT INTO [dbo].[PlatformStatuses] ([Value]) VALUES ('Не работает')
GO

INSERT INTO [dbo].[PlatformStatuses] ([Value]) VALUES ('Работает')
GO

INSERT INTO [dbo].[PlatformStatuses] ([Value]) VALUES ('Готовится к открытию')
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



INSERT INTO [dbo].[DeliveryTimes] ([Value]) VALUES ('Срочный')
GO

INSERT INTO [dbo].[DeliveryTimes] ([Value]) VALUES ('Предварительный')
GO


INSERT INTO [dbo].[OrderStatuses] ([Value]) VALUES ('Принят')
GO

INSERT INTO [dbo].[OrderStatuses] ([Value]) VALUES ('Готовится')
GO

INSERT INTO [dbo].[OrderStatuses] ([Value]) VALUES ('Приготовлен')
GO

INSERT INTO [dbo].[OrderStatuses] ([Value]) VALUES ('Упакован')
GO

INSERT INTO [dbo].[OrderStatuses] ([Value]) VALUES ('У курьера')
GO

INSERT INTO [dbo].[OrderStatuses] ([Value]) VALUES ('Доставлен')
GO



INSERT INTO [dbo].[OrderPays] ([Value]) VALUES ('Не оплачен')
GO

INSERT INTO [dbo].[OrderPays] ([Value]) VALUES ('Оплачен')
GO


INSERT INTO [dbo].[AspNetUsers]
           ([FirstName]
           ,[MiddleName]
           ,[LastName]
           ,[Phone]
           ,[IsHaveMedicalBook]
           ,[MedicalBookEnd]
           ,[EmployeeStatusId]
           ,[PositionId]
           ,[DateStart]
           ,[DateEnd]
           ,[IsAccess]
           ,[Email]
           ,[EmailConfirmed]
           ,[PasswordHash]
           ,[SecurityStamp]
           ,[PhoneNumber]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEndDateUtc]
           ,[LockoutEnabled]
           ,[AccessFailedCount]
           ,[UserName])
     VALUES
           ('FirstName',
           'MiddleName',
           'LastName',
           '',
           1,
           '2099-01-01 00:00:00.000',
           2,
           1,
           getdate(),
           NULL,
           1,
           NULL,
           0,
           'AHcI3+Ta5vX1AdLr/GRfB/SgbHewI5jNmJEb4jVcOMBFJ+XiO9Gg/7ua/F0/wGmzWQ==',
           'a78192d3-ca42-454b-ad01-9a98093bd1af',
           NULL,
           0,
           0,
           NULL,
           0,
           0,
           'test')
GO
