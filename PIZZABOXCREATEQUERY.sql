CREATE DATABASE PizzaBox;
USE PizzaBox;

CREATE TABLE ATopping( 
ID int NOT NULL,
ToppingName varchar(50),
ToppingPrice decimal(5,2),
PRIMARY KEY (ID));

CREATE TABLE ACrust( 
ID int NOT NULL,
CrustName varchar(50),
CrustPrice decimal(5,2),
PRIMARY KEY (ID));

CREATE TABLE ASize( 
ID int NOT NULL,
SizeName varchar(50),
SizePrice decimal(5,2),
PRIMARY KEY (ID));

CREATE TABLE ACustomer( 
ID int NOT NULL,
CustomerName varchar(50),
PRIMARY KEY (ID));

CREATE TABLE AStore( 
ID int NOT NULL,
StoreName varchar(50),
PRIMARY KEY (ID));

CREATE TABLE APizza(
ID int NOT NULL,
PizzaName varchar(50) NOT NULL,
Topping1 int,
Topping2 int,
Topping3 int,
Topping4 int,
Topping5 int,
Size int,
Crust int,
Price Decimal(5,2),
PRIMARY KEY (ID),
FOREIGN KEY (Topping1) REFERENCES ATopping(ID),
FOREIGN KEY (Topping2) REFERENCES ATopping(ID),
FOREIGN KEY (Topping3) REFERENCES ATopping(ID),
FOREIGN KEY (Topping4) REFERENCES ATopping(ID),
FOREIGN KEY (Topping5) REFERENCES ATopping(ID),
FOREIGN KEY (Size) REFERENCES ASize(ID),
FOREIGN KEY (Crust) REFERENCES ACrust(ID)
);

CREATE Table AOrder(
OrderID int NOT NULL,
StoreID int NOT NULL,
CustomerID int,
TimeOrdered DateTime NOT NULL,
Total Decimal(5,2),
PRIMARY KEY(OrderID),
FOREIGN KEY (StoreID) REFERENCES AStore(ID),
FOREIGN KEY (CustomerID) REFERENCES ACustomer(ID)
);


CREATE TABLE AOrderedPizza(
ID int NOT NULL,
OrderID int NOT NULL,
PizzaName varchar(50) NOT NULL,
Topping1 int,
Topping2 int,
Topping3 int,
Topping4 int,
Topping5 int,
Size int,
Crust int,
Price Decimal(5,2),
PRIMARY KEY (ID),
FOREIGN KEY (OrderID) REFERENCES AOrder(OrderID),
FOREIGN KEY (Topping1) REFERENCES ATopping(ID),
FOREIGN KEY (Topping2) REFERENCES ATopping(ID),
FOREIGN KEY (Topping3) REFERENCES ATopping(ID),
FOREIGN KEY (Topping4) REFERENCES ATopping(ID),
FOREIGN KEY (Topping5) REFERENCES ATopping(ID),
FOREIGN KEY (Size) REFERENCES ASize(ID),
FOREIGN KEY (Crust) REFERENCES ACrust(ID)
);

