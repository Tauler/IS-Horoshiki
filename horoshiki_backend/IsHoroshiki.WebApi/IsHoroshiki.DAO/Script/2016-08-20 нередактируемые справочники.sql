CREATE TABLE BuyProcesses
(
   Id   INT identity (1, 1)  NOT NULL,
   Value VARCHAR (100)		 NOT NULL,   
   PRIMARY KEY (Id)
);

go

CREATE TABLE StatusSites
(
   Id   INT identity (1, 1)  NOT NULL,
   Value VARCHAR (100)		 NOT NULL,   
   PRIMARY KEY (Id)
);

go

CREATE TABLE Positions
(
   Id   INT identity (1, 1)  NOT NULL,
   Value VARCHAR (100)		 NOT NULL,   
   PRIMARY KEY (Id)
);

go

CREATE TABLE Departments
(
   Id   INT identity (1, 1)  NOT NULL,
   Value VARCHAR (100)		 NOT NULL,   
   PRIMARY KEY (Id)
);

go

CREATE TABLE Subdivisions
(
   Id   INT identity (1, 1)  NOT NULL,
   Value VARCHAR (100)		 NOT NULL,   
   PRIMARY KEY (Id)
);

go

CREATE TABLE EmployeeStatuses
(
   Id   INT identity (1, 1)  NOT NULL,
   Value VARCHAR (100)		 NOT NULL,   
   PRIMARY KEY (Id)
);

go

CREATE TABLE OrderSettings
(
   Id   INT identity (1, 1)  NOT NULL,
   Value VARCHAR (100)		 NOT NULL,   
   PRIMARY KEY (Id)
);

go

CREATE TABLE PriceTypes
(
   Id   INT identity (1, 1)  NOT NULL,
   Value VARCHAR (100)		 NOT NULL,   
   PRIMARY KEY (Id)
);

go

CREATE TABLE DeliveryZones
(
   Id   INT identity (1, 1)  NOT NULL,
   Value VARCHAR (100)		 NOT NULL,   
   Time INT NOT NULL,
   PRIMARY KEY (Id)
);