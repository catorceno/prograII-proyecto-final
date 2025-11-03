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
CREATE TABLE SEATS (
	seatID		  INT		   PRIMARY KEY IDENTITY(1,1),
	seatingAreaID INT		   NOT NULL,
	[row]		  NVARCHAR(2)  NOT NULL, -- constraint?
	number		  INT		   NOT NULL,
	CONSTRAINT FK_seat_seatingArea FOREIGN KEY (seatingAreaID) REFERENCES SEATING_AREAS(seatingAreaID),
	CONSTRAINT CHK_seat_number CHECK(number > 0)
);

CREATE TABLE PERFORMERS (
	performerID INT			 PRIMARY KEY IDENTITY(1,1),
	userID		INT,
	[name]		NVARCHAR(50) NOT NULL,
	-- contact -- NULL
	rol			NVARCHAR(10) NOT NULL, -- organizer, performer. Para organizer userID obligatorio
	CONSTRAINT FK_performer_user FOREIGN KEY (userID) REFERENCES USERS(userID),
	CONSTRAINT CHK_performer_rol CHECK(rol IN ('organizer', 'performer'))
);
CREATE TABLE [EVENTS] ( -- festival
	eventID		  INT			PRIMARY KEY IDENTITY(1,1),
	theaterID	  INT			NOT NULL,
	performerID	  INT, -- organizer -- NULL
	title		  NVARCHAR(50),	
	[description] NVARCHAR(200),
	category	  NVARCHAR(10)  NOT NULL,
	[type]		  NVARCHAR(10)  NOT NULL,
	CONSTRAINT FK_event_theater FOREIGN KEY (theaterID) REFERENCES THEATERS(theaterID),
	CONSTRAINT FK_event_performer FOREIGN KEY (performerID) REFERENCES PERFORMERS(performerID),
	CONSTRAINT CHK_event_categoty CHECK(category IN ('music', 'dance', 'theatre')),
	CONSTRAINT CHK_event_type CHECK([type] IN ('festival', 'show', 'unique play'))
);
/*
festival --> unique event, different plays, and there are at least 1 different performer of a play
show --> unique event, different plays but organizer and performer are the same
unique play --> unique play, organizer and performer are the same

client: events, plays
theaters and performers: festival, complete show, unique play
*/
CREATE TABLE EVENT_PLAYS (
	eventID INT NOT NULL,
	playID  INT NOT NULL,
	CONSTRAINT FK_event_play FOREIGN KEY (eventID) REFERENCES [EVENTS](eventID),
	CONSTRAINT FK_play_event FOREIGN KEY (playID) REFERENCES PLAYS(playID)
);
CREATE TABLE PLAYS ( -- concert
	playID		  INT			PRIMARY KEY IDENTITY(1,9),
	performerID	  INT			NOT NULL,-- performer -- NULL
	title		  NVARCHAR(50)  NOT NULL,
	[description] NVARCHAR(75),
	playbillPDF	  NVARCHAR(200),
	duration	  INT			NOT NULL
);
CREATE TABLE PLAYS_PERFORMANCES (
	playID			
	performanceID
);
CREATE TABLE PERFORMANCES (
	performanceID
	[datetime]
	[state]
	CONSTRAINT CHK_event_datetime CHECK([datetime] > GETDATE()),
	CONSTRAINT CHK_event_duration CHECK(duration > 0),
	CONSTRAINT CHK_event_state CHECK([state] IN ('presale', 'onsale', 'soldout', 'completed', 'canceled'))
);

CREATE TABLE PRICE_ZONES (
	priceZoneID
	performanceID
	[name]
	pricePresale
	priceOnsale
);
CREATE TABLE PRICE_ZONE_SEATS (
	priceZoneSeatID
	priceZoneID
	seatID
	[state]
	CONSTRAINT FK_priceZoneSeat_eventPriceZone FOREIGN KEY (priceZoneID) REFERENCES EVENT_PRICE_ZONES(priceZoneID),
	CONSTRAINT FK_priceZoneSeat_seat FOREIGN KEY (seatID) REFERENCES SEATS(seatID),
	CONSTRAINT CHK_priceZoneSeat_state CHECK([state] IN ('available', 'occupied', 'disabled', 'completed'))
);


-- cada performance debe tener su propio mapa de asientos

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
	seatID		  INT			NOT NULL,
	price		  DECIMAL(10,2) NOT NULL,
	CONSTRAINT FK_tickets_reservation FOREIGN KEY (reservationID) REFERENCES RESERVATIONS(reservationID),
	CONSTRAINT FK_tickets_seat FOREIGN KEY (seatID) REFERENCES SEATS(seatID),
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