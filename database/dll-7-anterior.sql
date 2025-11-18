CREATE DATABASE TeatroTickets7;
GO
USE TeatroTickets7
GO

CREATE TABLE USERS (
	userID	   INT PRIMARY KEY IDENTITY(1,1),
	email	   NVARCHAR(100) NOT NULL,
	[password] NVARCHAR(200) NOT NULL,
	rol		   NVARCHAR(10)  NOT NULL,
	CONSTRAINT CHK_user_rol CHECK(rol IN ('theater', 'customer', 'performer'))
);
CREATE TABLE CUSTOMERS (
	customerID INT PRIMARY KEY IDENTITY(1,1),
	userID INT		    NOT NULL,
	[name] NVARCHAR(50) NOT NULL,
	phone  NVARCHAR(20) NOT NULL,
	CONSTRAINT FK_customer_user FOREIGN KEY (userID) REFERENCES USERS(userID)
);
CREATE TABLE PERFORMERS (
	performerID INT PRIMARY KEY IDENTITY(1,1),
	userID		INT		     NULL,
	[name]		NVARCHAR(50) NOT NULL,
	direction	NVARCHAR(50) NULL,
	contact		NVARCHAR(50) NULL,
	[state]		NVARCHAR(20) NOT NULL,
	[type]    NVARCHAR(20) NOT NULL,
	CONSTRAINT FK_performer_user FOREIGN KEY (userID) REFERENCES USERS(userID),
	CONSTRAINT CHK_performer_state CHECK([state] IN ('registered', 'not registered')), -- userID NOT NULL = registered
	CONSTRAINT CHK_performer_type CHECK ([type] IN ('academy', 'company', 'independent'))
);

/*if is register:
	- it has its own profile
	- type of performers:
		- academy, company: direction
		- independent
*/
CREATE TABLE THEATERS (
	theaterID INT PRIMARY KEY IDENTITY(1,1),
	userID	  INT		   NOT NULL,
	[name]	  NVARCHAR(50) NOT NULL,
	direction NVARCHAR(50) NOT NULL, -- REVISAR COMO GUARDAR ESTO
	capacity  INT		   NOT NULL,
	contact	  NVARCHAR(50) NULL,
	CONSTRAINT FK_theater_user FOREIGN KEY (userID) REFERENCES USERS(userID),
	CONSTRAINT CHK_theater_capacity CHECK(capacity > 0) -- capacity < ?
);
CREATE TABLE SEATING_AREAS (
	seatingAreaID INT PRIMARY KEY IDENTITY(1,1),
	theaterID	  INT		   NOT NULL,
	[name]		  NVARCHAR(50) NOT NULL, -- name.Upper
	capacity	  INT		   NOT NULL,
	CONSTRAINT FK_seatingArea_theater FOREIGN KEY (theaterID) REFERENCES THEATERS(theaterID),
	CONSTRAINT CHK_seatingArea_capacity CHECK(capacity > 0) -- && capacity <= theaterID.capacity 
);
CREATE TABLE SEATS (
	seatID		  INT PRIMARY KEY IDENTITY(1,1),
	seatingAreaID INT		  NOT NULL,
	[row]		  NVARCHAR(2) NOT NULL, -- row.Upper
	number		  INT		  NOT NULL, -- REVISAR QUE TIPO DE DATOS DEBERÍA SER?
	CONSTRAINT FK_seat_seatingArea FOREIGN KEY (seatingAreaID) REFERENCES SEATING_AREAS(seatingAreaID),
	CONSTRAINT CHK_seat_number CHECK(number > 0)
);

CREATE TABLE [EVENTS] (
	eventID		  INT PRIMARY KEY IDENTITY(1,1),
	theaterID	  INT			NOT NULL,
	performerID	  INT			NULL,
	title		  NVARCHAR(50)  NULL,
	[description] NVARCHAR(200) NULL,
	playbillPDF	  NVARCHAR(200) NULL, -- REVISAR como guardar
	category	  NVARCHAR(20)  NOT NULL,
	[type]		  NVARCHAR(20)  NOT NULL,
	[state]		  NVARCHAR(10)  NOT NULL,
	CONSTRAINT FK_event_theater FOREIGN KEY (theaterID) REFERENCES THEATERS(theaterID),
	CONSTRAINT FK_event_performer FOREIGN KEY (performerID) REFERENCES PERFORMERS(performerID),
	CONSTRAINT CHK_event_category CHECK(category IN ('music', 'dance', 'theatre')),
	CONSTRAINT CHK_event_type CHECK([type] IN ('festival', 'show', 'unique play')),
	CONSTRAINT CHK_event_state CHECK([state] IN ('draft', 'published', 'completed'))
);
CREATE TABLE PLAYS (
	playID		  INT PRIMARY KEY IDENTITY(1,1),
	eventID		  INT			NOT NULL,
	performerID	  INT		    NOT NULL,
	title		  NVARCHAR(50)  NOT NULL,
	[description] NVARCHAR(200) NULL,
	duration	  INT			NOT NULL,
	CONSTRAINT FK_play_event FOREIGN KEY (eventID) REFERENCES [EVENTS](eventID),
	CONSTRAINT FK_play_performer FOREIGN KEY (performerID) REFERENCES PERFORMERS(performerID)
);
CREATE TABLE PERFORMANCES (
	performanceID INT PRIMARY KEY IDENTITY(1,1),
	[datetime]	  DATETIME NOT NULL,
	[state]		  NVARCHAR(10) NOT NULL,
	CONSTRAINT CHK_performance_datetime CHECK([datetime] > GETDATE()),
	CONSTRAINT CHK_performance_state CHECK([state] IN ('presale', 'onsale', 'soldout', 'completed', 'canceled'))
);
CREATE TABLE PLAY_PERFORMANCES (
	playID		  INT NOT NULL,
	performanceID INT NOT NULL,
	CONSTRAINT FK_playPerformance_play FOREIGN KEY (playID) REFERENCES PLAYS(playID),
	CONSTRAINT FK_playPerformance_performance FOREIGN KEY (performanceID) REFERENCES PERFORMANCES(performanceID)
);

CREATE TABLE PRICE_ZONES (
	priceZoneID	  INT PRIMARY KEY IDENTITY(1,1),
	performanceID INT		    NOT NULL,
	[name]		  NVARCHAR(50)  NOT NULL,
	pricePresale  DECIMAL(10,2) NULL,
	price         DECIMAL(10,2) NOT NULL,
	CONSTRAINT CHK_priceZone_pricePresale CHECK(pricePresale >= 0),
	CONSTRAINT CHK_priceZone_price CHECK(price >= 0)
);
CREATE TABLE PRICE_ZONE_SEATS (
	priceZoneSeatID INT PRIMARY KEY IDENTITY(1,1),
	priceZoneID		INT			 NOT NULL,
	seatID			INT			 NOT NULL,
	[state]			NVARCHAR(10) NOT NULL CONSTRAINT DF_priceZoneSeat_state DEFAULT 'available',
	CONSTRAINT FK_priceZoneSeat_priceZone FOREIGN KEY (priceZoneID) REFERENCES PRICE_ZONES(priceZoneID),
	CONSTRAINT FK_priceZoneSeat_seat FOREIGN KEY (seatID) REFERENCES SEATS(seatID),
	CONSTRAINT CHK_priceZoneSeat_state CHECK([state] IN ('available', 'occupied', 'disabled', 'completed'))
);

CREATE TABLE RESERVATIONS (
	reservationID INT PRIMARY KEY IDENTITY(1,1),
	customerID	  INT			NULL,
	performanceID INT			NOT NULL,
	total		  DECIMAL(10,2) NULL,
	[date]		  DATETIME		NOT NULL CONSTRAINT DF_reservation_date DEFAULT GETDATE(), -- < performance.datetime
	CONSTRAINT FK_reservation_customer FOREIGN KEY (customerID) REFERENCES CUSTOMERS(customerID),
	CONSTRAINT FK_reservation_performance FOREIGN KEY (performanceID) REFERENCES PERFORMANCES(performanceID),
	CONSTRAINT CHK_reservation_total CHECK (total >= 0)
);
CREATE TABLE TICKETS (
	ticketID		INT PRIMARY KEY IDENTITY(1,1),
	reservationID   INT NOT NULL,
	priceZoneSeatID INT NOT NULL,
	price			INT NOT NULL,
	CONSTRAINT FK_ticket_reservation FOREIGN KEY (reservationID) REFERENCES RESERVATIONS(reservationID),
	CONSTRAINT FK_ticket_priceZoneSeat FOREIGN KEY (priceZoneSeatID) REFERENCES PRICE_ZONE_SEATS(priceZoneSeatID),
	CONSTRAINT CHK_ticket_price CHECK(price >= 0)
);
CREATE TABLE PAYMENTS (
	paymentID	  INT PRIMARY KEY IDENTITY(1,1),
	reservationID INT		    NOT NULL,
	method		  NVARCHAR(20)  NOT NULL,
	amount		  DECIMAL(10,2) NOT NULL,
	[date]		  DATETIME		NOT NULL CONSTRAINT DF_payment_date DEFAULT GETDATE(), -- <= reservationID.date
	CONSTRAINT FK_payment_reservation FOREIGN KEY (reservationID) REFERENCES RESERVATIONS(reservationID),
	CONSTRAINT CHK_payment_method CHECK(method IN ('qr', 'tarjeta', 'efectivo')),
	CONSTRAINT CHK_payment_amount CHECK(amount > 0)
);