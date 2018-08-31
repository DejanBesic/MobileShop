DROP TABLE IF EXISTS Shopping;
DROP TABLE IF EXISTS Cart;
DROP TABLE IF EXISTS Customer;
DROP TABLE IF EXISTS Administrator;
DROP TABLE IF EXISTS Mobile;
DROP TABLE IF EXISTS Additional;
DROP TABLE IF EXISTS Battery;
DROP TABLE IF EXISTS Camera;
DROP TABLE IF EXISTS Characteristics;
DROP TABLE IF EXISTS Memory;
DROP TABLE IF EXISTS PhonePlatform;
DROP TABLE IF EXISTS PackageContent;
DROP TABLE IF EXISTS Screen;
DROP TABLE IF EXISTS Sound;
DROP TABLE IF EXISTS Communication;


CREATE TABLE Customer (
	Id int PRIMARY KEY IDENTITY,
	Username varchar(255),
	FirstName varchar(255),
	LastName varchar(255),
	CustomerAddress varchar(255),
	Email varchar(255),
	CustomerPassword varchar(255),
	Blocked bit,
	Activated bit,
	IsAdmin bit,
	BlockedBy int,
	FOREIGN KEY (BlockedBy) REFERENCES Customer(Id)
);

CREATE TABLE Additional (
	Id int PRIMARY KEY IDENTITY,
	AdditionalDescription varchar(255)
);

CREATE TABLE Battery (
	Id int  PRIMARY KEY IDENTITY,
	Capacity varchar(255)
);

CREATE TABLE Camera (
	Id int  PRIMARY KEY IDENTITY,
	BackCamera varchar(255),
	BackCameraChar varchar(255),
	FrontCamera varchar(255),
	FrontCameraChar varchar(255),
	Video varchar(255)
);

CREATE TABLE Characteristics (
	Id int  PRIMARY KEY IDENTITY,
	SIM varchar(255),
	DualSIM bit,
	Dimensions varchar(255),
	PhoneWeight varchar(255)
);

CREATE TABLE Communication (
	Id int  PRIMARY KEY IDENTITY,
	DataTransfer varchar(255),
	Network2G varchar(255),
	Network3G varchar(255),
	Network4G varchar(255),
	USB varchar(255),
	WiFi varchar(255),
	Bluetooth varchar(255),
	NFC bit,
	GPS bit,
	PhoneMessages varchar(255)
);

CREATE TABLE Memory (
	Id int  PRIMARY KEY IDENTITY,
	Intern varchar(255),
	Extern varchar(255),
);

CREATE TABLE PackageContent (
	Id int  PRIMARY KEY IDENTITY,
	Content varchar(255),
);

CREATE TABLE PhonePlatform (
	Id int  PRIMARY KEY IDENTITY,
	OS varchar(255),
	RAM varchar(255),
);

CREATE TABLE Screen (
	Id int  PRIMARY KEY IDENTITY,
	Size varchar(255),
	Resolution varchar(255),
	ScreenType varchar(255),
	Touch bit
);

CREATE TABLE Sound (
	Id int  PRIMARY KEY IDENTITY,
	FMRadio bit,
	Port35mm bit,
	HDVoice bit,
);

CREATE TABLE Mobile (
	Id int PRIMARY KEY IDENTITY,
	About varchar(255),
	Price float,
	PlatformId int,
	ScreenId int,
	CameraId int,
	MemoryId int,
	SoundId int,
	CommunicationId int,
	BatteryId int,
	CharacteristicsId int,
	AdditionalId int,
	PackageContentId int,
	FOREIGN KEY (PlatformId) REFERENCES PhonePlatform(Id),
	FOREIGN KEY (ScreenId) REFERENCES Screen(Id),
	FOREIGN KEY (CameraId) REFERENCES Camera(Id),
	FOREIGN KEY (MemoryId) REFERENCES Memory(Id),
	FOREIGN KEY (SoundId) REFERENCES Sound(Id),
	FOREIGN KEY (CommunicationId) REFERENCES Communication(Id),
	FOREIGN KEY (AdditionalId) REFERENCES Additional(Id),
	FOREIGN KEY (PackageContentId) REFERENCES PackageContent(Id),
	FOREIGN KEY (BatteryId) REFERENCES Battery(Id),
	FOREIGN KEY (CharacteristicsId) REFERENCES Characteristics(Id),
);

CREATE TABLE Cart (
	Id int PRIMARY KEY IDENTITY,
	CustomerId int,
	MobileId int,
	FOREIGN KEY (CustomerId) REFERENCES Customer(Id),
	FOREIGN KEY (MobileId) REFERENCES Mobile(Id),
);

CREATE TABLE Shopping (
	Id int PRIMARY KEY IDENTITY,
	CustomerId int,
	MobileId int,
	ShoppingNumber int,
	FOREIGN KEY (MobileId) REFERENCES Mobile(Id),
	FOREIGN KEY (CustomerId) REFERENCES Customer(Id),
);

CREATE TABLE Shop (
	Id int PRIMARY KEY IDENTITY,
	ShopName varchar(255),
	ContactPhone varchar(255),
	ContactMobilePhone varchar(255),
	ContactAddress varchar(255),
	HirePayment bit,
	OpenTime varchar(255),
);

CREATE TABLE Shop_Mobiles(
	Id int PRIMARY KEY IDENTITY,
	ShopId int,
	MobileId int,
	FOREIGN KEY (MobileId) REFERENCES Mobile(Id),
	FOREIGN KEY (ShopId) REFERENCES Shop(Id),
);