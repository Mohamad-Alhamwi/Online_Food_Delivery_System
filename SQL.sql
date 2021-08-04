CREATE DATABASE OnlineFoodOrderingSystem

USE OnlineFoodOrderingSystem

CREATE TABLE User_(
	id INT IDENTITY(1,1),
	first_name NVARCHAR(50),
	last_name NVARCHAR(50),
	email NVARCHAR(320) NOT NULL,
	pwd NVARCHAR(100) NOT NULL,
	phoneNo NVARCHAR(30),
	created_at DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	updated_at DATETIME,
	PRIMARY KEY (id),
	CONSTRAINT UN_Email UNIQUE (email)
);

CREATE TABLE Role_(
	id INT IDENTITY(1,1),
	role_name NVARCHAR(50) NOT NULL,
	created_at DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	updated_at DATETIME,
	CONSTRAINT UN_RoleName UNIQUE (role_name),
	PRIMARY KEY (id)
);

CREATE TABLE UserRole(
	id INT IDENTITY(1,1),
	id_user INT NOT NULL,
	id_role INT NOT NULL,
	CONSTRAINT UN_UserRole UNIQUE (id_user, id_role),
	FOREIGN KEY (id_user) REFERENCES User_(id) ON DELETE CASCADE,
	FOREIGN KEY (id_role) REFERENCES Role_(id) ON DELETE CASCADE,
	PRIMARY KEY (id)
);

CREATE TABLE Address_(
	id INT IDENTITY(1,1),
	address_name NVARCHAR(50) NOT NULL,
	city NVARCHAR(50) NOT NULL,
	town NVARCHAR(50) NOT NULL,
	neighborhood NVARCHAR(50) NOT NULL,
	street NVARCHAR(50) NOT NULL,
	building_name NVARCHAR(50) NOT NULL,
	building_no INT NOT NULL,
	flat_no INT NOT NULL,
	CONSTRAINT UN_AddressName UNIQUE (address_name),
	PRIMARY KEY (id)
);

CREATE TABLE UserAddress(
	id INT IDENTITY(1,1),
	id_user INT NOT NULL,
	id_address INT NOT NULL,
	CONSTRAINT UN_UserAddress UNIQUE (id_user, id_address),
	FOREIGN KEY (id_user) REFERENCES User_(id) ON DELETE CASCADE,
	FOREIGN KEY (id_address) REFERENCES Address_(id) ON DELETE CASCADE,
	PRIMARY KEY (id)
);

CREATE TABLE PaymentCard(
	id INT IDENTITY(1,1),
	id_user INT NOT NULL,
	card_name NVARCHAR(50) NOT NULL,
	card_no NVARCHAR(50) NOT NULL,
	expiration_data DATETIME NOT NULL,
	cvv INT NOT NULL,
	CONSTRAINT UN_CardName UNIQUE (card_name),
	FOREIGN KEY (id_user) REFERENCES User_(id) ON DELETE CASCADE,
	PRIMARY KEY (id)
);

