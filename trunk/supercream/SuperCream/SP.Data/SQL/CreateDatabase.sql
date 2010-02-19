USE SuperCreamDB
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Account_Address') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Account DROP CONSTRAINT FK_Account_Address
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Account_Customer') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Account DROP CONSTRAINT FK_Account_Customer
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Account_Terms') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Account DROP CONSTRAINT FK_Account_Terms
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_ContactDetail_Customer') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE ContactDetail DROP CONSTRAINT FK_ContactDetail_Customer
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_DeliveryItem_InvoiceItem') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE DeliveryItem DROP CONSTRAINT FK_DeliveryItem_InvoiceItem
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_FoundationFacility_Address') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE FoundationFacility DROP CONSTRAINT FK_FoundationFacility_Address
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Invoice_Account') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE InvoiceHeader DROP CONSTRAINT FK_Invoice_Account
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Invoice_Terms') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE InvoiceHeader DROP CONSTRAINT FK_Invoice_Terms
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_InvoiceItem_Invoice') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE InvoiceItem DROP CONSTRAINT FK_InvoiceItem_Invoice
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_InvoiceItem_OrderLine') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE InvoiceItem DROP CONSTRAINT FK_InvoiceItem_OrderLine
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Note_Customer') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Note DROP CONSTRAINT FK_Note_Customer
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Note_Order') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Note DROP CONSTRAINT FK_Note_Order
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Order_Customer') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE OrderHeader DROP CONSTRAINT FK_Order_Customer
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_OrderLine_Order') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE OrderLine DROP CONSTRAINT FK_OrderLine_Order
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_OrderLine_Product') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE OrderLine DROP CONSTRAINT FK_OrderLine_Product
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Outlet_Address') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Outlet DROP CONSTRAINT FK_Outlet_Address
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Outlet_Customer') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Outlet DROP CONSTRAINT FK_Outlet_Customer
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Phone_ContactDetail') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Phone DROP CONSTRAINT FK_Phone_ContactDetail
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Phone_PhoneNoType') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Phone DROP CONSTRAINT FK_Phone_PhoneNoType
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_PriceList_Customer') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE PriceListHeader DROP CONSTRAINT FK_PriceList_Customer
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_PriceListItem_PriceList') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE PriceListItem DROP CONSTRAINT FK_PriceListItem_PriceList
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_PriceListItem_Product') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE PriceListItem DROP CONSTRAINT FK_PriceListItem_Product
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('FK_Product_VatCode') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1)
ALTER TABLE Product DROP CONSTRAINT FK_Product_VatCode
;


IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('Account') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Account
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('Address') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Address
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('ContactDetail') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE ContactDetail
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('Customer') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Customer
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('DeliveryItem') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE DeliveryItem
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('FoundationFacility') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE FoundationFacility
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('InvoiceHeader') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE InvoiceHeader
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('InvoiceItem') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE InvoiceItem
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('Note') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Note
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('OrderHeader') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE OrderHeader
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('OrderLine') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE OrderLine
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('Outlet') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Outlet
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('Phone') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Phone
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('PhoneNoType') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE PhoneNoType
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('PriceListHeader') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE PriceListHeader
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('PriceListItem') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE PriceListItem
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('Product') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Product
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('ProformaInvoice') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE ProformaInvoice
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('Terms') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE Terms
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('VatCode') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE VatCode
;


CREATE TABLE Account ( 
	ID int NOT NULL,
	InvoiceAddressID int NULL,
	CustomerID int NULL,
	TermTypeID int NULL,
	AlphaPrefixOrPostFix smallint NULL,
	AlphaID varchar(20) NULL
)
;

CREATE TABLE Address ( 
	ID int NOT NULL,
	AddressType smallint NULL,
	AddressLines varchar(512) NULL,
	Town varchar(50) NULL,
	County varchar(50) NULL,
	PostCode varchar(8) NULL
)
;

CREATE TABLE ContactDetail ( 
	ID int NOT NULL,
	CustomerID int NULL,
	ShopID int NULL,
	JobRole varchar(50) NULL,
	Title varchar(50) NULL,
	FirstName varchar(50) NULL,
	LastName varchar(50) NULL,
	InitialNote varchar(8000) NULL
)
;

CREATE TABLE Customer ( 
	ID int NOT NULL,
	AlphaPrefixOrPostfix smallint NULL,
	AlphaID varchar(20) NULL,
	Name varchar(50) NULL,
	VatRegistrationNumber varchar(25) NULL
)
;

CREATE TABLE DeliveryItem ( 
	ID int NOT NULL,
	VanID int NULL,
	InvoiceItemID int NULL,
	DriverName varchar(50) NULL,
	DeliveryDate datetime NULL,
	NextDeliveryDate datetime NULL,
	DeliveryComplete bit NULL
)
;

CREATE TABLE FoundationFacility ( 
	ID int NOT NULL,
	AddressID int NULL,
	CompanyName varchar(50) NULL,
	VatRegistrationNumber varchar(50) NULL,
	OfficePhoneNumber1 varchar(50) NULL,
	OfficePhoneNumber2 varchar(50) NULL
)
;

CREATE TABLE InvoiceHeader ( 
	ID int NOT NULL,
	AccountID int NULL,
	InvoiceTermsID int NULL,
	InvoiceType smallint NULL,
	AlphaPrefixOrPostFix smallint NULL,
	AlphaID varchar(20) NULL,
	InvoiceDate datetime NULL,
	SpecialInstructions varchar(8000) NULL
)
;

CREATE TABLE InvoiceItem ( 
	ID int NOT NULL,
	InvoiceID int NULL,
	OrderLineID int NULL,
	ProductDescription varchar(150) NULL,
	NoOfUnits int NULL,
	QtyPerUnit float NULL,
	PricePerUnit decimal(10,2) NULL,
	RRP decimal(10,2) NULL
)
;

CREATE TABLE Note ( 
	ID int NOT NULL,
	ParentNoteID int NULL,
	DateNoteTaken datetime NULL,
	SpokeTo varchar(50) NULL,
	NoteText varchar(8000) NULL
)
;

CREATE TABLE OrderHeader ( 
	ID int NOT NULL,
	CustomerID int NULL,
	AlphaPrefixOrPostFix smallint NULL,
	AlphaID varchar(20) NULL,
	OrderDate datetime NULL
)
;

CREATE TABLE OrderLine ( 
	ID int NOT NULL,
	OrderID int NULL,
	ProductID int NULL,
	OrderLineStatus smallint NULL,
	QtyPerUnit int NULL,
	NoOfUnits int NULL,
	Discount float NULL
)
;

CREATE TABLE Outlet ( 
	ID int NOT NULL,
	CustomerID int NULL,
	AddressID int NULL,
	Name varchar(50) NULL,
	OpeningHoursStart smallint NULL,
	OpeningHoursClose smallint NULL,
	Notes varchar(8000) NULL
)
;

CREATE TABLE Phone ( 
	ID int NOT NULL,
	ContactDetailID int NULL,
	PhoneTypeID smallint NULL,
	Description varchar(20) NULL
)
;

CREATE TABLE PhoneNoType ( 
	ID int NOT NULL,
	Description varchar(20) NULL
)
;

CREATE TABLE PriceListHeader ( 
	ID int NOT NULL,
	ProductID int NULL,
	CustomerID int NULL,
	PriceListType smallint NULL,
	DateEffectiveFrom datetime NULL,
	DateEffectiveTo datetime NULL
)
;

CREATE TABLE PriceListItem ( 
	ID int NOT NULL,
	PriceListID int NULL,
	ProductID int NULL,
	Price decimal(10,2) NULL
)
;

CREATE TABLE Product ( 
	ID int NOT NULL,
	VatCodeID int NULL,
	AlphaPrefixOrPostFix smallint NULL,
	AlphaID varchar(20) NULL,
	Description varchar(150) NULL,
	PLDescription varchar(50) NULL,
	RRP decimal(10,2) NULL,
	Discount float NULL
)
;

CREATE TABLE ProformaInvoice ( 
	ID int NOT NULL
)
;

CREATE TABLE Terms ( 
	ID int NOT NULL,
	Description varchar(128) NULL
)
;

CREATE TABLE VatCode ( 
	ID int NOT NULL,
	Code varchar(20) NULL,
	Description varchar(150) NULL
)
;


ALTER TABLE Account ADD CONSTRAINT PK_Account 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE Address ADD CONSTRAINT PK_Address 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE ContactDetail ADD CONSTRAINT PK_ContactDetail 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE Customer ADD CONSTRAINT PK_Customer 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE DeliveryItem ADD CONSTRAINT PK_DeliveryItem 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE FoundationFacility ADD CONSTRAINT PK_FoundationFacility 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE InvoiceHeader ADD CONSTRAINT PK_Invoice 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE InvoiceItem ADD CONSTRAINT PK_InvoiceItem 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE Note ADD CONSTRAINT PK_Note 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE OrderHeader ADD CONSTRAINT PK_Order 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE OrderLine ADD CONSTRAINT PK_OrderLine 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE Outlet ADD CONSTRAINT PK_Outlet 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE Phone ADD CONSTRAINT PK_Phone 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE PhoneNoType ADD CONSTRAINT PK_PhoneNoType 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE PriceListHeader ADD CONSTRAINT PK_PriceList 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE PriceListItem ADD CONSTRAINT PK_PriceListItem 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE Product ADD CONSTRAINT PK_Product 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE ProformaInvoice ADD CONSTRAINT PK_ProformaInvoice 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE Terms ADD CONSTRAINT PK_Terms 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE VatCode ADD CONSTRAINT PK_VatCode 
	PRIMARY KEY CLUSTERED (ID)
;



ALTER TABLE Account ADD CONSTRAINT FK_Account_Address 
	FOREIGN KEY (InvoiceAddressID) REFERENCES Address (ID)
;

ALTER TABLE Account ADD CONSTRAINT FK_Account_Customer 
	FOREIGN KEY (CustomerID) REFERENCES Customer (ID)
;

ALTER TABLE Account ADD CONSTRAINT FK_Account_Terms 
	FOREIGN KEY (TermTypeID) REFERENCES Terms (ID)
;

ALTER TABLE ContactDetail ADD CONSTRAINT FK_ContactDetail_Customer 
	FOREIGN KEY (CustomerID) REFERENCES Customer (ID)
;

ALTER TABLE DeliveryItem ADD CONSTRAINT FK_DeliveryItem_InvoiceItem 
	FOREIGN KEY (InvoiceItemID) REFERENCES InvoiceItem (ID)
;

ALTER TABLE FoundationFacility ADD CONSTRAINT FK_FoundationFacility_Address 
	FOREIGN KEY (AddressID) REFERENCES Address (ID)
;

ALTER TABLE InvoiceHeader ADD CONSTRAINT FK_Invoice_Account 
	FOREIGN KEY (AccountID) REFERENCES Account (ID)
;

ALTER TABLE InvoiceHeader ADD CONSTRAINT FK_Invoice_Terms 
	FOREIGN KEY (InvoiceTermsID) REFERENCES Terms (ID)
;

ALTER TABLE InvoiceItem ADD CONSTRAINT FK_InvoiceItem_Invoice 
	FOREIGN KEY (InvoiceID) REFERENCES InvoiceHeader (ID)
;

ALTER TABLE InvoiceItem ADD CONSTRAINT FK_InvoiceItem_OrderLine 
	FOREIGN KEY (OrderLineID) REFERENCES OrderLine (ID)
;

ALTER TABLE Note ADD CONSTRAINT FK_Note_Customer 
	FOREIGN KEY (ParentNoteID) REFERENCES Customer (ID)
;

ALTER TABLE Note ADD CONSTRAINT FK_Note_Order 
	FOREIGN KEY (ParentNoteID) REFERENCES OrderHeader (ID)
;

ALTER TABLE OrderHeader ADD CONSTRAINT FK_Order_Customer 
	FOREIGN KEY (CustomerID) REFERENCES Customer (ID)
;

ALTER TABLE OrderLine ADD CONSTRAINT FK_OrderLine_Order 
	FOREIGN KEY (OrderID) REFERENCES OrderHeader (ID)
;

ALTER TABLE OrderLine ADD CONSTRAINT FK_OrderLine_Product 
	FOREIGN KEY (ProductID) REFERENCES Product (ID)
;

ALTER TABLE Outlet ADD CONSTRAINT FK_Outlet_Address 
	FOREIGN KEY (AddressID) REFERENCES Address (ID)
;

ALTER TABLE Outlet ADD CONSTRAINT FK_Outlet_Customer 
	FOREIGN KEY (CustomerID) REFERENCES Customer (ID)
;

ALTER TABLE Phone ADD CONSTRAINT FK_Phone_ContactDetail 
	FOREIGN KEY (ContactDetailID) REFERENCES ContactDetail (ID)
;

ALTER TABLE Phone ADD CONSTRAINT FK_Phone_PhoneNoType 
	FOREIGN KEY (PhoneTypeID) REFERENCES PhoneNoType (ID)
;

ALTER TABLE PriceListHeader ADD CONSTRAINT FK_PriceList_Customer 
	FOREIGN KEY (CustomerID) REFERENCES Customer (ID)
;

ALTER TABLE PriceListItem ADD CONSTRAINT FK_PriceListItem_PriceList 
	FOREIGN KEY (PriceListID) REFERENCES PriceListHeader (ID)
;

ALTER TABLE PriceListItem ADD CONSTRAINT FK_PriceListItem_Product 
	FOREIGN KEY (ProductID) REFERENCES Product (ID)
;

ALTER TABLE Product ADD CONSTRAINT FK_Product_VatCode 
	FOREIGN KEY (VatCodeID) REFERENCES VatCode (ID)
;
