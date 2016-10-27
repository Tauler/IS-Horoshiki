alter table [dbo].[DeliveryZoneTypes] add ZIndex int not null default(0);



alter table [dbo].[DeliveryZoneTypes] add Priority int not null default(0);

GO

UPDATE [dbo].[DeliveryZoneTypes] SET ZIndex = 4, Priority = 1 WHERE Guid = '48922505-A864-400D-B3D0-F4F70DDEB1E6';



UPDATE [dbo].[DeliveryZoneTypes] SET ZIndex = 3, Priority = 2 WHERE Guid = 'B5874A2C-2711-42CC-B88A-54E8259FE7EC';



UPDATE [dbo].[DeliveryZoneTypes] SET ZIndex = 2, Priority = 3 WHERE Guid = 'FC8EDEDC-BAB1-42BA-A8CA-448657B7D05F';



UPDATE [dbo].[DeliveryZoneTypes] SET ZIndex = 1, Priority = 4 WHERE Guid = '66BC1D1D-8B35-491D-A57F-CB5A4574295B';

