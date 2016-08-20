CREATE TABLE BuyProcesses
(
   Id   INT              NOT NULL,
   Value VARCHAR (100)    NOT NULL,   
   PRIMARY KEY (Id)
);

go

CREATE TABLE StatusSites
(
   Id   INT              NOT NULL,
   Value VARCHAR (100)    NOT NULL,   
   PRIMARY KEY (Id)
);

go

CREATE TABLE Positions
(
   Id   INT              NOT NULL,
   Value VARCHAR (100)    NOT NULL,   
   PRIMARY KEY (Id)
);

go

CREATE TABLE Departments
(
   Id   INT              NOT NULL,
   Value VARCHAR (100)    NOT NULL,   
   PRIMARY KEY (Id)
);

go

CREATE TABLE Subdivisions
(
   Id   INT              NOT NULL,
   Value VARCHAR (100)    NOT NULL,   
   PRIMARY KEY (Id)
);

go

CREATE TABLE EmployeeStatuses
(
   Id   INT              NOT NULL,
   Value VARCHAR (100)    NOT NULL,   
   PRIMARY KEY (Id)
);

go

CREATE TABLE OrderSettings
(
   Id   INT              NOT NULL,
   Value VARCHAR (100)    NOT NULL,   
   PRIMARY KEY (Id)
);

go

CREATE TABLE PriceTypes
(
   Id   INT              NOT NULL,
   Value VARCHAR (100)    NOT NULL,   
   PRIMARY KEY (Id)
);

go

CREATE TABLE DeliveryZoneTypes
(
   Id   INT              NOT NULL,
   Value VARCHAR (100)    NOT NULL,   
   PRIMARY KEY (Id)
);