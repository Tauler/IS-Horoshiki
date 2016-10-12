INSERT INTO [dbo].[BuyProcesses] ([Guid],[Value]) VALUES ('FBBAE261-CD71-4FA3-AF63-E04FC1E5CB18', 'Доставка');
GO

INSERT INTO [dbo].[BuyProcesses] ([Guid],[Value]) VALUES ('1C47B31F-D28B-4DEF-BE40-E588CADD853B', 'Самовывоз');
GO

INSERT INTO [dbo].[BuyProcesses] ([Guid],[Value]) VALUES ('A3774B0F-DCA2-4262-B010-176E2DCC832E', 'Ресторан');
GO


INSERT INTO [dbo].[Positions] ([Guid],[Value]) VALUES ('449F1830-172A-4AEC-BC29-6BB446CF8861', 'Операционный директор');
GO

INSERT INTO [dbo].[Positions] ([Guid],[Value]) VALUES ('27C9376B-47B6-4ECA-8920-E8A0E63F267C', 'Управляющий рестораном');
GO

INSERT INTO [dbo].[Positions] ([Guid],[Value]) VALUES ('8AB6DB9C-36AC-4760-B2E2-43445EE11520', 'Менеджер смены');
GO

INSERT INTO [dbo].[Positions] ([Guid],[Value]) VALUES ('4551B436-BB84-4A80-906D-F5AD5DC37D76', 'Администратор');
GO

INSERT INTO [dbo].[Positions] ([Guid],[Value]) VALUES ('29F56215-45C8-484B-839C-3F2E22D5F0B7', 'Повар сушист');
GO

INSERT INTO [dbo].[Positions] ([Guid],[Value]) VALUES ('EB4C9D17-B79D-46E4-BEBB-C2218AFB50CE', 'Повар - универсал');
GO

INSERT INTO [dbo].[Positions] ([Guid],[Value]) VALUES ('418B8D56-EDC9-4E16-B6F8-CE68C52BDB79', 'Пиццер');
GO

INSERT INTO [dbo].[Positions] ([Guid],[Value]) VALUES ('F3031481-E4F1-4CA0-939A-78BE83C0951D', 'Повар холодного цеха');
GO

INSERT INTO [dbo].[Positions] ([Guid],[Value]) VALUES ('C6EAD0FF-B75A-4333-977C-AC24647734F7', 'Упаковщик');
GO

INSERT INTO [dbo].[Positions] ([Guid],[Value]) VALUES ('C1FABE74-06E0-4FC6-BE79-553FC2E9232B', 'Курьер');
GO



INSERT INTO [dbo].[Departments] ([Guid],[Value]) VALUES ('AC252958-75C9-4AFE-A685-A9E853E52994', 'Колл-центр')
GO

INSERT INTO [dbo].[Departments] ([Guid],[Value]) VALUES ('9890056E-D74B-4057-AA54-91B403021D65', 'Администрация')
GO

INSERT INTO [dbo].[Departments] ([Guid],[Value]) VALUES ('A011AF0E-6303-49A9-B29B-4F93E543D762', 'Производство')
GO

INSERT INTO [dbo].[Departments] ([Guid],[Value]) VALUES ('D8CCFE34-38A0-47FC-AD64-2C13BDA0678B', 'Доставка')
GO



INSERT INTO [dbo].[SubDepartments] ([Guid],[DepartmentId] ,[Value]) VALUES ('16CFC67A-478B-476A-85A0-58E5C07941D8', 3, 'Заготовительный цех')
GO

INSERT INTO [dbo].[SubDepartments] ([Guid],[DepartmentId] ,[Value]) VALUES ('FCD7586F-EDDB-4531-BE83-E006BEB766D3', 3, 'Цех суши')
GO

INSERT INTO [dbo].[SubDepartments] ([Guid],[DepartmentId] ,[Value]) VALUES ('F2E916DC-21BB-47FB-8863-7ACF15DAAB02', 3, 'Холодный цех')
GO

INSERT INTO [dbo].[SubDepartments] ([Guid],[DepartmentId] ,[Value]) VALUES ('4A1872B9-D334-4878-A895-0E4D2E7CDA70', 3, 'Цех пиццы')
GO

INSERT INTO [dbo].[SubDepartments] ([Guid],[DepartmentId] ,[Value]) VALUES ('F94E9F2D-895B-40FD-8715-7ECB9E43BB61', 3, 'Упаковка')
GO

INSERT INTO [dbo].[SubDepartments] ([Guid],[DepartmentId] ,[Value]) VALUES ('441BB133-844B-452E-A720-F4E25E330528', 3, 'Уборка')
GO




INSERT INTO [dbo].[PlatformStatuses] ([Guid],[Value]) VALUES ('8A3A8D0B-70B2-49CD-9CC2-F1401FF2EA66', 'Не работает')
GO

INSERT INTO [dbo].[PlatformStatuses] ([Guid],[Value]) VALUES ('391F4D8C-B810-45A1-86C6-B74C2ABB4BEE', 'Работает')
GO

INSERT INTO [dbo].[PlatformStatuses] ([Guid],[Value]) VALUES ('757AC0A9-2E65-46C8-940B-28D31C177249', 'Готовится к открытию')
GO


INSERT INTO [dbo].[PriceTypes] ([Guid],[Value]) VALUES ('82B1488F-9C62-4CDB-9CE2-46C612E0A1ED', 'Омск')
GO

INSERT INTO [dbo].[PriceTypes] ([Guid],[Value]) VALUES ('6F1C8501-ABA0-4811-8546-F4E303444DE0', 'Москва')
GO

INSERT INTO [dbo].[PriceTypes] ([Guid],[Value]) VALUES ('9CAD8B57-15FB-4967-B2F7-113A8C12237A', 'Санкт-Петербург')
GO



INSERT INTO [dbo].[DeliveryZoneTypes] ([Guid],[Value], [Time], [Background], [Opacity], [BorderColor]) VALUES ('48922505-A864-400D-B3D0-F4F70DDEB1E6', 'Зона 1', 0, '#FF0000', 1, '#918383')
GO

INSERT INTO [dbo].[DeliveryZoneTypes] ([Guid],[Value], [Time], [Background], [Opacity], [BorderColor]) VALUES ('B5874A2C-2711-42CC-B88A-54E8259FE7EC', 'Зона 2', 0, '#FF8000', 1, '#918383')
GO

INSERT INTO [dbo].[DeliveryZoneTypes] ([Guid],[Value], [Time], [Background], [Opacity], [BorderColor]) VALUES ('FC8EDEDC-BAB1-42BA-A8CA-448657B7D05F', 'Зона 3', 0, '#FFFF00', 1, '#918383')
GO

INSERT INTO [dbo].[DeliveryZoneTypes] ([Guid],[Value], [Time], [Background], [Opacity], [BorderColor]) VALUES ('66BC1D1D-8B35-491D-A57F-CB5A4574295B', 'Зона 4', 0, '#80FF00', 1, '#918383')
GO



INSERT INTO [dbo].[EmployeeStatuses] ([Guid],[Value]) VALUES  ('F64423DC-FB22-41F3-8FAA-DA9B38EA671D', 'Стажер')
GO

INSERT INTO [dbo].[EmployeeStatuses] ([Guid],[Value]) VALUES  ('B725328D-922A-4C21-9652-1108DB0C8BD3', 'Работает')
GO

INSERT INTO [dbo].[EmployeeStatuses] ([Guid],[Value]) VALUES  ('9CF6F1D7-BD82-4411-A92B-95E8605A4257', 'Отпуск')
GO

INSERT INTO [dbo].[EmployeeStatuses] ([Guid],[Value]) VALUES  ('104688A6-9CD2-4FB9-AB03-9DA1B5474BE0', 'Уволен')
GO



INSERT INTO [dbo].[DeliveryTimes] ([Guid],[Value]) VALUES ('D91F1F3A-1B22-4BEB-B0F6-1CBB737D10A4', 'Срочный')
GO

INSERT INTO [dbo].[DeliveryTimes] ([Guid],[Value]) VALUES ('484F85DB-B0E0-4B83-A0F3-261127B0401B', 'Предварительный')
GO


INSERT INTO [dbo].[OrderStatuses] ([Guid],[Value]) VALUES ('20B199A8-CE9E-466C-88A3-61D46DF8ABEA', 'Принят')
GO

INSERT INTO [dbo].[OrderStatuses] ([Guid],[Value]) VALUES ('14EC1420-A986-471B-842E-9A89DF047B3E', 'Готовится')
GO

INSERT INTO [dbo].[OrderStatuses] ([Guid],[Value]) VALUES ('9509126D-9ECB-4145-9ED1-706297C0DCAE', 'Приготовлен')
GO

INSERT INTO [dbo].[OrderStatuses] ([Guid],[Value]) VALUES ('11668A6C-D0F3-4FAF-9E36-F5390E6F4D53', 'Упакован')
GO

INSERT INTO [dbo].[OrderStatuses] ([Guid],[Value]) VALUES ('6A798F95-80B1-4D14-B62A-33AC54F51316', 'У курьера')
GO

INSERT INTO [dbo].[OrderStatuses] ([Guid],[Value]) VALUES ('ECEF9E2A-1B48-47CA-8358-20C92CDE3917', 'Доставлен')
GO



INSERT INTO [dbo].[OrderPays] ([Guid],[Value]) VALUES ('48C1E747-3563-41F9-8B76-BFB41E3721D6', 'Не оплачен')
GO

INSERT INTO [dbo].[OrderPays] ([Guid],[Value]) VALUES ('0BC37D74-D91B-4E3C-B1CD-75091F409F4A', 'Оплачен')
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
