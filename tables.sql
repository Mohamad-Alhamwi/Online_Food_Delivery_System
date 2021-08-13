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

CREATE TABLE Report(
	id INT IDENTITY(1,1),
	id_admin INT,
	report_title NVARCHAR(50) NOT NULL,
	report_description NVARCHAR(500) NOT NULL,
	issued_at DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	FOREIGN KEY (id_admin) REFERENCES User_(id) ON DELETE CASCADE,
	PRIMARY KEY (id)
);

CREATE TABLE Restaurant(
	id INT IDENTITY(1,1),
	id_seller INT NOT NULL,
	restaurant_name NVARCHAR(50) NOT NULL,
	city NVARCHAR(50) NOT NULL,
	town NVARCHAR(50) NOT NULL,
	logo IMAGE,
	CONSTRAINT UN_RestaurantName UNIQUE (restaurant_name),
	CONSTRAINT UN_SellerId UNIQUE (id_seller),
	FOREIGN KEY (id_seller) REFERENCES User_(id) ON DELETE CASCADE,
	PRIMARY KEY (id)
);

CREATE TABLE Cuisine(
	id INT IDENTITY(1,1),
	cuisine_name NVARCHAR(50) NOT NULL,
	created_at DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	updated_at DATETIME,
	CONSTRAINT UN_CuisineName UNIQUE (cuisine_name),
	PRIMARY KEY (id)
);

CREATE TABLE RestaurantCuisine(
	id INT IDENTITY(1,1),
	id_restaurant INT NOT NULL,
	id_cuisine INT NOT NULL,
	CONSTRAINT UN_Cuisine UNIQUE (id_restaurant, id_cuisine),
	FOREIGN KEY (id_restaurant) REFERENCES Restaurant(id) ON DELETE CASCADE,
	FOREIGN KEY (id_cuisine) REFERENCES Cuisine(id) ON DELETE CASCADE,
	PRIMARY KEY (id)
);

CREATE TABLE OrderState(
	id INT IDENTITY(1,1),
	state_name NVARCHAR(50) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE Order_(
	id INT IDENTITY(1,1),
	id_customer INT NOT NULL,
	id_state INT NOT NULL,
	delivery_address NVARCHAR(50) NOT NULL,
	ordered_at DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	es_delivery_at DATETIME,
	delivered_at DATETIME,
	note NVARCHAR(50),
	total_price DECIMAL(10,2) NOT NULL,
	PRIMARY KEY (id),
	FOREIGN KEY (id_customer) REFERENCES User_(id) ON DELETE CASCADE,
	FOREIGN KEY (id_state) REFERENCES OrderState(id) ON DELETE CASCADE,
);

CREATE TABLE Product(
	id INT IDENTITY(1,1),
	id_restaurant INT NOT NULL,
	product_name NVARCHAR(50) NOT NULL,
	price DECIMAL(10,2) NOT NULL,
	product_weight DECIMAL(10,2) NOT NULL,
	product_description NVARCHAR(500) NOT NULL,
	product_image IMAGE,
	created_at DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	updated_at DATETIME,
	PRIMARY KEY (id),
	FOREIGN KEY (id_restaurant) REFERENCES Restaurant(id) ON DELETE CASCADE
);

CREATE TABLE Category(
	id INT IDENTITY(1,1),
	category_name NVARCHAR(50) NOT NULL,
	catogory_description NVARCHAR(500) NOT NULL,
	created_at DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	updated_at DATETIME,
	CONSTRAINT UN_CategoryName UNIQUE (category_name),
	PRIMARY KEY (id)
);

CREATE TABLE ProductCategory(
	id INT IDENTITY(1,1),
	id_product INT NOT NULL,
	id_category INT NOT NULL,
	CONSTRAINT UN_ProductCategory UNIQUE (id_product, id_category),
	FOREIGN KEY (id_product) REFERENCES Product(id) ON DELETE CASCADE,
	FOREIGN KEY (id_category) REFERENCES Category(id) ON DELETE CASCADE,
	PRIMARY KEY (id)
);

CREATE TABLE OrderItem(
	id INT IDENTITY(1,1),
	id_order INT NOT NULL,
	id_product INT NOT NULL,
	quantity INT NOT NULL,
	CONSTRAINT UN_OrderItem UNIQUE (id_order, id_product),
	FOREIGN KEY (id_order) REFERENCES Order_(id) ON DELETE CASCADE,
	FOREIGN KEY (id_product) REFERENCES Product(id),
	PRIMARY KEY (id)
);

CREATE TABLE Menu(
	id INT IDENTITY(1,1),
	id_restaurant INT NOT NULL,
	menu_name INT NOT NULL,
	menu_image IMAGE,
	total_price DECIMAL(10,2) NOT NULL,
	Menu_description NVARCHAR(500) NOT NULL,
	CONSTRAINT UN_RestaurantMenu UNIQUE (id_restaurant, menu_name),
	FOREIGN KEY (id_restaurant) REFERENCES Restaurant(id) ON DELETE CASCADE,
	PRIMARY KEY (id)
);

CREATE TABLE MenuItem(
	id INT IDENTITY(1,1),
	id_Menu INT NOT NULL,
	id_product INT NOT NULL,
	quantity INT NOT NULL,
	CONSTRAINT UN_MenuItem UNIQUE (id_Menu, id_product),
	FOREIGN KEY (id_Menu) REFERENCES Menu(id) ON DELETE CASCADE,
	FOREIGN KEY (id_product) REFERENCES Product(id),
	PRIMARY KEY (id)
);

CREATE TABLE UserFavourite(
	id INT IDENTITY(1,1),
	id_product INT,
	id_menu INT,
	id_user INT NOT NULL,
	CONSTRAINT UN_UserFavouriteProduct UNIQUE (id_user, id_product),
	CONSTRAINT UN_UserFavouriteMenu UNIQUE (id_user, id_menu),
	FOREIGN KEY (id_product) REFERENCES Product(id),
	FOREIGN KEY (id_menu) REFERENCES Menu(id),
	FOREIGN KEY (id_user) REFERENCES USER_(id) ON DELETE CASCADE,
	PRIMARY KEY (id)
);

CREATE TABLE UserRating(
	id INT IDENTITY(1,1),
	id_product INT,
	id_menu INT,
	id_user INT NOT NULL,
	star DECIMAL(2, 2) NOT NULL,
	comment NVARCHAR(500),
	created_at DATETIME DEFAULT CURRENT_TIMESTAMP NOT NULL,
	updated_at DATETIME,
	CONSTRAINT UN_UserRatingProduct UNIQUE (id_user, id_product),
	CONSTRAINT UN_UserRatingMenu UNIQUE (id_user, id_menu),
	FOREIGN KEY (id_product) REFERENCES Product(id),
	FOREIGN KEY (id_menu) REFERENCES Menu(id),
	FOREIGN KEY (id_user) REFERENCES USER_(id) ON DELETE CASCADE,
	PRIMARY KEY (id)
);