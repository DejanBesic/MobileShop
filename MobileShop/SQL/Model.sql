DROP TABLE IF EXISTS Shopping;
DROP TABLE IF EXISTS Cart;
DROP TABLE IF EXISTS Images;
DROP TABLE IF EXISTS Shop_Mobiles;
DROP TABLE IF EXISTS Customer;
DROP TABLE IF EXISTS Shop;
DROP TABLE IF EXISTS Administrator;
DROP TABLE IF EXISTS Mobile;
DROP TABLE IF EXISTS Additional;
DROP TABLE IF EXISTS Battery;
DROP TABLE IF EXISTS Camera;
DROP TABLE IF EXISTS CameraCharacteristics;
DROP TABLE IF EXISTS CameraMP;
DROP TABLE IF EXISTS Characteristics;
DROP TABLE IF EXISTS Memory;
DROP TABLE IF EXISTS RAM;
DROP TABLE IF EXISTS OperativeSystem;
DROP TABLE IF EXISTS Proccessor;
DROP TABLE IF EXISTS PackageContent;
DROP TABLE IF EXISTS Screen;
DROP TABLE IF EXISTS Sound;
DROP TABLE IF EXISTS Communication;
DROP TABLE IF EXISTS Video;


CREATE TABLE Shop (
	Id int PRIMARY KEY IDENTITY,
	ShopName varchar(255),
	ContactPhone varchar(255),
	ContactMobilePhone varchar(255),
	ContactAddress varchar(255),
	HirePayment bit,
	OpenTime varchar(255),
);

CREATE TABLE Customer (
	Id int PRIMARY KEY IDENTITY,
	FirstName varchar(255),
	LastName varchar(255),
	CustomerAddress varchar(255),
	Email varchar(255),
	CustomerPassword varchar(255),
	Blocked bit,
	Activated bit,
	IsAdmin bit,
	IsRootAdmin bit,
	ShopAdminId int,
	FOREIGN KEY (ShopAdminId) REFERENCES Shop(Id)
);

CREATE TABLE Battery (
	Id int  PRIMARY KEY IDENTITY,
	Capacity varchar(255)
);

CREATE TABLE Camera (
	Id int  PRIMARY KEY IDENTITY,
	MP varchar(255),
);

CREATE TABLE Memory (
	Id int  PRIMARY KEY IDENTITY,
	Size varchar(255),
);

CREATE TABLE OperativeSystem (
	Id int PRIMARY KEY IDENTITY,
	OS varchar(255)
);

CREATE TABLE RAM (
	Id int PRIMARY KEY IDENTITY,
	Memory varchar(255),
);

CREATE TABLE Mobile (
	Id int PRIMARY KEY IDENTITY,
	MobileName varchar(255),
	About varchar(255),
	SIM varchar(255),
	DualSIM bit,
	Proccessor varchar(255),
	Dimensions varchar(255),
	PhoneWeight varchar(255),
	PackageContent varchar(255),
	Size varchar(255),
	Resolution varchar(255),
	ScreenType varchar(255),
	DataTransfer varchar(255),
	Network2G varchar(255),
	Network3G varchar(255),
	Network4G varchar(255),
	FrontCameraChar varchar(255),
	BackCameraChar varchar(255),
	USB varchar(255),
	WiFi varchar(255),
	Bluetooth varchar(255),
	NFC bit,
	GPS bit,
	PhoneMessages varchar(255),
	AdditionalDescription varchar(255),
	Video varchar(255),
	Touch bit,
	FMRadio bit,
	Port35mm bit,
	HDVoice bit,

	BatteryId int,
	FrontCameraId int,
	BackCameraId int,
	InternMemoryId int,
	ExternMemoryId int,
	RamId int,
	OsId int,

	FOREIGN KEY (RamId) REFERENCES RAM(Id),
	FOREIGN KEY (OsId) REFERENCES OperativeSystem(Id),
	FOREIGN KEY (InternMemoryId) REFERENCES Memory(Id),
	FOREIGN KEY (ExternMemoryId) REFERENCES Memory(Id),
	FOREIGN KEY (FrontCameraId) REFERENCES Camera(Id),
	FOREIGN KEY (BackCameraId) REFERENCES Camera(Id),
	FOREIGN KEY (BatteryId) REFERENCES Battery(Id),
);

CREATE TABLE Images(
	Id int PRIMARY KEY IDENTITY,
	ImageBinary varbinary(MAX),
	MobileId int,
	FOREIGN KEY (MobileId) REFERENCES Mobile(Id),
);

CREATE TABLE Shop_Mobiles(
	Id int PRIMARY KEY IDENTITY,
	ShopId int,
	MobileId int,
	MobilesLeft int,
	Price float,

	FOREIGN KEY (MobileId) REFERENCES Mobile(Id),
	FOREIGN KEY (ShopId) REFERENCES Shop(Id),
);

CREATE TABLE Shopping (
	Id int PRIMARY KEY IDENTITY,
	CustomerId int,
	MobileId int,
	Price float,
	ShopId int,
	ShoppingStatus varchar(255),
	PurchasingDate Datetime,

	FOREIGN KEY (CustomerId) REFERENCES Customer(Id),
	FOREIGN KEY (MobileId) REFERENCES Mobile(Id),
	FOREIGN KEY (ShopId) REFERENCES Shop(Id),
);