INSERT INTO [dbo].[BuyProcesses] ([Value]) VALUES ('��������');
GO

INSERT INTO [dbo].[BuyProcesses] ([Value]) VALUES ('���������');
GO

INSERT INTO [dbo].[BuyProcesses] ([Value]) VALUES ('��������');
GO


INSERT INTO [dbo].[Positions] ([Value]) VALUES ('������������ ��������');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('����������� ����������');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('�������� �����');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('�������������');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('����� ������');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('����� - ���������');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('������');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('����� ��������� ����');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('���������');
GO

INSERT INTO [dbo].[Positions] ([Value]) VALUES ('������');
GO



INSERT INTO [dbo].[Departments] ([Value]) VALUES ('����-�����')
GO

INSERT INTO [dbo].[Departments] ([Value]) VALUES ('�������������')
GO

INSERT INTO [dbo].[Departments] ([Value]) VALUES ('������������')
GO

INSERT INTO [dbo].[Departments] ([Value]) VALUES ('��������')
GO



INSERT INTO [dbo].[SubDepartments] ([DepartmentId] ,[Value]) VALUES (3, '��������������� ���')
GO

INSERT INTO [dbo].[SubDepartments] ([DepartmentId] ,[Value]) VALUES (3, '��� ����')
GO

INSERT INTO [dbo].[SubDepartments] ([DepartmentId] ,[Value]) VALUES (3, '�������� ���')
GO

INSERT INTO [dbo].[SubDepartments] ([DepartmentId] ,[Value]) VALUES (3, '��� �����')
GO

INSERT INTO [dbo].[SubDepartments] ([DepartmentId] ,[Value]) VALUES (3, '��������')
GO

INSERT INTO [dbo].[SubDepartments] ([DepartmentId] ,[Value]) VALUES (3, '������')
GO




INSERT INTO [dbo].[PlatformStatuses] ([Value]) VALUES ('�� ��������')
GO

INSERT INTO [dbo].[PlatformStatuses] ([Value]) VALUES ('��������')
GO

INSERT INTO [dbo].[PlatformStatuses] ([Value]) VALUES ('��������� � ��������')
GO


INSERT INTO [dbo].[PriceTypes] ([Value]) VALUES ('����')
GO

INSERT INTO [dbo].[PriceTypes] ([Value]) VALUES ('������')
GO

INSERT INTO [dbo].[PriceTypes] ([Value]) VALUES ('�����-���������')
GO



INSERT INTO [dbo].[DeliveryZones] ([Value], [Time]) VALUES ('���� 1', 0)
GO

INSERT INTO [dbo].[DeliveryZones] ([Value], [Time]) VALUES ('���� 2', 0)
GO

INSERT INTO [dbo].[DeliveryZones] ([Value], [Time]) VALUES ('���� 3', 0)
GO

INSERT INTO [dbo].[DeliveryZones] ([Value], [Time]) VALUES ('���� 4', 0)
GO



INSERT INTO [dbo].[EmployeeStatuses] ([Value]) VALUES  ('������')
GO

INSERT INTO [dbo].[EmployeeStatuses] ([Value]) VALUES  ('��������')
GO

INSERT INTO [dbo].[EmployeeStatuses] ([Value]) VALUES  ('������')
GO

INSERT INTO [dbo].[EmployeeStatuses] ([Value]) VALUES  ('������')
GO



INSERT INTO [dbo].[DeliveryTimes] ([Value]) VALUES ('�������')
GO

INSERT INTO [dbo].[DeliveryTimes] ([Value]) VALUES ('���������������')
GO


INSERT INTO [dbo].[OrderStatuses] ([Value]) VALUES ('������')
GO

INSERT INTO [dbo].[OrderStatuses] ([Value]) VALUES ('���������')
GO

INSERT INTO [dbo].[OrderStatuses] ([Value]) VALUES ('�����������')
GO

INSERT INTO [dbo].[OrderStatuses] ([Value]) VALUES ('��������')
GO

INSERT INTO [dbo].[OrderStatuses] ([Value]) VALUES ('� �������')
GO

INSERT INTO [dbo].[OrderStatuses] ([Value]) VALUES ('���������')
GO



INSERT INTO [dbo].[OrderPays] ([Value]) VALUES ('�� �������')
GO

INSERT INTO [dbo].[OrderPays] ([Value]) VALUES ('�������')
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
