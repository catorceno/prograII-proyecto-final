CREATE DATABASE TeatroTickets2;
GO
USE TeatroTickets2;
GO

CREATE TABLE USERS (
	userID	   INT			 PRIMARY KEY IDENTITY(1,1),
	email	   NVARCHAR(100) NOT NULL,
	[password] NVARCHAR(200) NOT NULL,
	rol		   NVARCHAR(10)  NOT NULL,
	CONSTRAINT CHK_user_rol CHECK ( rol IN ('theater', 'customer', 'performer'))
);

CREATE TABLE THEATERS (
	theaterID	  INT			PRIMARY KEY IDENTITY(1,1),
	userID		  INT			NOT NULL,
	[name]		  NVARCHAR(50)  NOT NULL,
	direction	  NVARCHAR(100) NOT NULL,
	manager		  NVARCHAR(50)  NOT NULL, -- REVISAR
	phone		  NVARCHAR(20), -- REVISAR: si habrá más de un número de contacto para el museo, sera el del manager? el contacto del vendedor
	email		  NVARCHAR(100),
	capacity INT			NOT NULL,
	CONSTRAINT FK_theater_user FOREIGN KEY (userID) REFERENCES USERS(userID),
	CONSTRAINT CHK_theater_capacity CHECK(capacity > 0)
);

CREATE TABLE SEATING_AREAS (
	seatingAreaID INT		    PRIMARY KEY IDENTITY(1,1),
	theaterID	  INT		    NOT NULL,
	[name]	      NVARCHAR(50)  NOT NULL,
	capacity	  INT		    NOT NULL, -- capacity <= theaterID.capacity
	CONSTRAINT FK_seatingArea_theater FOREIGN KEY (theaterID) REFERENCES THEATERS(theaterID),
	CONSTRAINT CHK_seatingArea_capacity CHECK(capacity > 0)
);

CREATE TABLE BUTACAS (
	butacaID	  INT		   PRIMARY KEY IDENTITY(1,1),
	seatingAreaID INT		   NOT NULL,
	[row]		  NVARCHAR(2)  NOT NULL, -- constraint?
	number		  INT		   NOT NULL,
	CONSTRAINT FK_butaca_seatingArea FOREIGN KEY (seatingAreaID) REFERENCES SEATING_AREAS(seatingAreaID),
	CONSTRAINT CHK_butaca_number CHECK(number > 0)
);

CREATE TABLE [EVENTS] (
	eventID		  INT			PRIMARY KEY IDENTITY(1,1),
	theaterID	  INT			NOT NULL,
	title		  NVARCHAR(50)  NOT NULL,	
	[description] NVARCHAR(200) NOT NULL,
	category	  NVARCHAR(10)  NOT NULL,
	playbillPDF   NVARCHAR(255),
	[datetime]	  DATETIME		NOT NULL,
	duration	  INT			NOT NULL,
	[state]		  NVARCHAR(10)  NOT NULL,
	CONSTRAINT FK_event_theater FOREIGN KEY (theaterID) REFERENCES THEATERS(theaterID),
	CONSTRAINT CHK_event_categoty CHECK(category IN ('music', 'dance', 'theatre')),
	CONSTRAINT CHK_event_datetime CHECK([datetime] > GETDATE()),
	CONSTRAINT CHK_event_duration CHECK(duration > 0),
	CONSTRAINT CHK_event_state CHECK([state] IN ('active', 'completed', 'presale', 'soldout', 'canceled'))
);
-- un mismo evento puede suceder en diferentes días y horarios
-- un evento puede tener diferentes obras --> como en el Festival de Contemporáneo

CREATE TABLE EVENT_PRICE_ZONES (
	priceZoneID INT			  PRIMARY KEY IDENTITY(1,1),
	eventID		INT			  NOT NULL,
	[name]		NVARCHAR(10)  NOT NULL,
	price		DECIMAL(10,2) NOT NULL,
	CONSTRAINT FK_eventPriceZone_event FOREIGN KEY (eventID) REFERENCES [EVENTS](eventID),
	CONSTRAINT FK_eventPriceZone_price CHECK(price >= 0)
);

CREATE TABLE EVENT_PRICE_ZONE_SEATS (
	priceZoneSeatID INT PRIMARY KEY IDENTITY(1,1),
	priceZoneID		INT			 NOT NULL,
	butacaID		INT			 NOT NULL,
	[state]			NVARCHAR(10) NOT NULL,
	CONSTRAINT FK_eventPriceZoneSeat_eventPriceZone FOREIGN KEY (priceZoneID) REFERENCES EVENT_PRICE_ZONES(priceZoneID),
	CONSTRAINT FK_eventPriceZoneSeat_butaca FOREIGN KEY (butacaID) REFERENCES BUTACAS(butacaID),
	CONSTRAINT CHK_eventPriceZoneSeat_state CHECK([state] IN ('available', 'taken', 'disabled'))
);

-- cada evento debe tener su propio mapa de asientos

CREATE TABLE RESERVATIONS (
	reservationID INT			PRIMARY KEY IDENTITY(1,1),
	userID		  INT			NULL, -- must be role = customer
	eventID		  INT			NOT NULL,
	[date]		  DATETIME		NOT NULL, -- date <= eventID.datetime, default = GETDATE()
	total		  DECIMAL(10,2) NOT NULL,
	CONSTRAINT FK_reservation_user FOREIGN KEY (userID) REFERENCES USERS(userID),
	CONSTRAINT FK_reservation_event FOREIGN KEY (eventID) REFERENCES [EVENTS](eventID)
);

CREATE TABLE TICKETS (
	ticketID	  INT			PRIMARY KEY IDENTITY(1,1),
	reservationID INT			NOT NULL,
	butacaID	  INT			NOT NULL,
	price		  DECIMAL(10,2) NOT NULL,
	CONSTRAINT FK_tickets_reservation FOREIGN KEY (reservationID) REFERENCES RESERVATIONS(reservationID),
	CONSTRAINT FK_tickets_butaca FOREIGN KEY (butacaID) REFERENCES BUTACAS(butacaID),
	CONSTRAINT CHK_tickets_price CHECK(price >= 0)
);

CREATE TABLE PAYMENTS (
	paymentID	  INT			PRIMARY KEY IDENTITY(1,1),
	reservationID INT			NOT NULL,
	method		  NVARCHAR(10)	NOT NULL,
	amount		  DECIMAL(10,2) NOT NULL,
	[date]		  DATETIME		NOT NULL, -- date <= reservationID.date, default = GETDATE()
	CONSTRAINT FK_payment_reservation FOREIGN KEY (reservationID) REFERENCES RESERVATIONS(reservationID),
	CONSTRAINT CHK_payment_amount CHECK(amount > 0)
);