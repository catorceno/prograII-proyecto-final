USE TeatroTickets7
GO

---------------------------- REGISTRAR UN TEATRO
-- crear cuenta
DECLARE @email1 NVARCHAR(100) = 'theater1@gmail.com'
DECLARE @password1 NVARCHAR(200) = 'theater1123'
INSERT INTO USERS(email, password, rol)
VALUES (@email1, @password1, 'theater');
GO
-- formulario con los datos del teatro
DECLARE @userID1 INT = 1
DECLARE @name1 NVARCHAR(50) = 'Teatro Municipal 1'
DECLARE @direction1 NVARCHAR(50) = 'doble via km.7'
DECLARE @capacity1 INT = 10
DECLARE @contact NVARCHAR(50) = 'encargado: 77999914, ventas: 76400014'
INSERT INTO THEATERS(userID, [name], direction, capacity, contact)
VALUES (@userID1, @name1, @direction1, @capacity1, @contact);
GO
-- mapa del teatro
INSERT INTO SEATING_AREAS(theaterID, [name], capacity)
VALUES
	(1, 'platea', 5),
	(1, 'anfiteatro', 5);
GO
INSERT INTO SEATS(seatingAreaID, [row], number)
VALUES
	(1, 'A', 1),
	(1, 'A', 3),
	(1, 'A', 5),
	(1, 'B', 3),
	(1, 'B', 4),
	(2, 'A', 1),
	(2, 'A', 3),
	(2, 'A', 5),
	(2, 'B', 2),
	(2, 'B', 4);
GO

---------------------------- REGISTRAR UN EVENTO COMO TEATRO
	-- categoria: festival
-- crear usuario
INSERT INTO USERS(email, password, rol)
VALUES ('fases@gmail.com', 'fases123', 'performer');
GO
-- formulario con los datos del performer
INSERT INTO PERFORMERS(userID, name, direction, contact, state, type)
VALUES
	(1, 'fases', 'villa', '76869337', 'registered', 'academy'),
	(NULL, 'cuerpos libres', 'primer anillo', NULL, 'not registered', 'academy'),
	(NULL, 'FIDC', 'tercer anillo', '76468337', 'not registered', 'academy'),
	(NULL, 'arte y canto', 'tercer anillo', '76468337', 'not registered', 'academy'),
	(NULL, 'Maria Juarez, Andrés ayala y Lucio Loayza', NULL, NULL, 'not registered', 'independent');
GO
-- crear evento, obras y funciones
INSERT INTO [EVENTS](theaterID, performerID, title, description, playbillPDF, category, type, state)
VALUES (1, 1, 'Festival Internacional de Danza Contemporánea', 'festival', NULL, 'dance', 'festival', 'published');
GO
INSERT INTO PLAYS(eventID, performerID, title, description, duration)
VALUES 
	(2, 1, 'sempiterna', 'description1', 60),
	(2, 2, 'vuelta', 'description2', 60),
	(2, 3, 'acero', 'description3', 60),
	(2, 4, 'acostumbrarse pero puede cambiar', 'description4', 60),
	(2, 5, 'camila mia', 'description5', 60);
GO
INSERT INTO PERFORMANCES(datetime, state)
VALUES
	('2025-12-1 19:00:00', 'onsale'),
	('2025-12-2 19:00:00', 'onsale'),
	('2025-12-3 19:00:00', 'onsale'),
	('2025-12-4 19:00:00', 'onsale'),
	('2025-12-5 19:00:00', 'onsale');
GO
INSERT INTO PLAY_PERFORMANCES(playID, performanceID)
VALUES
	(2, 1),
	(3, 2),
	(4, 3),
	(5, 4),
	(6, 5);
GO

-- crear evento - categoria: show
INSERT INTO USERS(email, password, rol)
VALUES ('bellart@gmail.com', 'bellart123', 'performer');
GO
INSERT INTO PERFORMERS(userID, name, direction, contact, state, type)
VALUES 
	(3, 'bellart, escuela de ballet', 'direction2', 'contact', 'registered', 'academy');
GO
INSERT INTO [EVENTS](theaterID, performerID, title, description, playbillPDF, category, type, state)
VALUES (1, 7, 'corazón de tinta', 'description3', 'pdf', 'dance', 'show', 'published');
GO
select * from PERFORMANCES
INSERT INTO PLAYS(eventID, performerID, title, description, duration)
VALUES 
	(3, 7, 'aladín', 'description1', 120),
	(3, 7, 'la bella y la bestia', 'description2', 120);
GO
INSERT INTO PERFORMANCES(datetime, state)
VALUES
	('2025-11-7', 'onsale'),
	('2025-11-8', 'onsale'),
	('2025-11-9', 'onsale'),
	('2025-11-10', 'onsale'),
	('2025-11-11', 'onsale'),
	('2025-11-12', 'onsale'),
	('2025-11-13', 'onsale');
GO
INSERT INTO PLAY_PERFORMANCES(playID, performanceID)
VALUES
	(7, 6),
	(8, 6),
	(7, 7),
	(7, 8),
	(7, 9),
	(8, 10),
	(8, 11),
	(8, 12);
GO

-- crear evento - categoria: unique play
INSERT INTO [EVENTS]()
VALUES ();
GO
INSERT INTO PLAYS()
VALUES ();
GO
INSERT INTO PERFORMANCES()
VALUES ();
GO

---------------------------- DETERMINAR PRECIOS
INSERT INTO PRICE_ZONES(performanceID, name, price)
VALUES
	(1, 'platea', 0),
	(2, 'platea', 0),
	(3, 'platea', 0),
	(4, 'platea', 0),
	(5, 'platea', 35);
GO
INSERT INTO PRICE_ZONE_SEATS(priceZoneID, seatID, state)
VALUES
	(1, 1, 'available'),
	(1, 2, 'available'),
	(1, 3, 'available'),
	(1, 4, 'available'),
	(1, 5, 'available'),
	(1, 6, 'available'),
	(1, 7, 'available'),
	(1, 8, 'available'),
	(1, 9, 'available'),
	(1, 10, 'available'),
	(2, 1, 'available'),
	(2, 2, 'available'),
	(2, 3, 'available'),
	(2, 4, 'available'),
	(2, 5, 'available'),
	(2, 6, 'available'),
	(2, 7, 'available'),
	(2, 8, 'available'),
	(2, 9, 'available'),
	(2, 10, 'available'),
	(3, 1, 'available'),
	(3, 2, 'available'),
	(3, 3, 'available'),
	(3, 4, 'available'),
	(3, 5, 'available'),
	(3, 6, 'available'),
	(3, 7, 'available'),
	(3, 8, 'available'),
	(3, 9, 'available'),
	(3, 10, 'available'),
	(4, 1, 'available'),
	(4, 2, 'available'),
	(4, 3, 'available'),
	(4, 4, 'available'),
	(4, 5, 'available'),
	(4, 6, 'available'),
	(4, 7, 'available'),
	(4, 8, 'available'),
	(4, 9, 'available'),
	(4, 10, 'available'),
	(5, 1, 'available'),
	(5, 2, 'available'),
	(5, 3, 'available'),
	(5, 4, 'available'),
	(5, 5, 'available'),
	(5, 6, 'available'),
	(5, 7, 'available'),
	(5, 8, 'available'),
	(5, 9, 'available'),
	(5, 10, 'available');
GO
INSERT INTO PRICE_ZONES(performanceID, name, pricePresale, price)
VALUES
	(6, 'platea', 160, 180),
	(7, 'platea', 140, 160),
	(8, 'platea', 140, 160),
	(9, 'platea', 140, 160),
	(10, 'platea', 140, 160),
	(11, 'platea', 140, 160),
	(12, 'platea', 140, 160);
GO
INSERT INTO PRICE_ZONE_SEATS(priceZoneID, seatID)
VALUES
	(11, 1),
	(11, 2),
	(11, 3),
	(11, 4),
	(11, 5),
	(11, 6),
	(11, 7),
	(11, 8),
	(11, 9),
	(11, 10),
	(12, 1),
	(12, 2),
	(12, 3),
	(12, 4),
	(12, 5),
	(12, 6),
	(12, 7),
	(12, 8),
	(12, 9),
	(12, 10),
	(13, 1),
	(13, 2),
	(13, 3),
	(13, 4),
	(13, 5),
	(13, 6),
	(13, 7),
	(13, 8),
	(13, 9),
	(13, 10),
	(14, 1),
	(14, 2),
	(14, 3),
	(14, 4),
	(14, 5),
	(14, 6),
	(14, 7),
	(14, 8),
	(14, 9),
	(14, 10),
	(15, 1),
	(15, 2),
	(15, 3),
	(15, 4),
	(15, 5),
	(15, 6),
	(15, 7),
	(15, 8),
	(15, 9),
	(15, 10),
	(16, 1),
	(16, 2),
	(16, 3),
	(16, 4),
	(16, 5),
	(16, 6),
	(16, 7),
	(16, 8),
	(16, 9),
	(16, 10),
	(17, 1),
	(17, 2),
	(17, 3),
	(17, 4),
	(17, 5),
	(17, 6),
	(17, 7),
	(17, 8),
	(17, 9),
	(17, 10);
GO

---------------------------- COMPRAR TICKETS
INSERT INTO RESERVATIONS(performanceID, total)
VALUES 
	(1, 0),
	(2, 0),
	(3, 0),
	(4, 0),
	(5, 0);
GO
INSERT INTO TICKETS(reservationID, priceZoneSeatID, price)
VALUES
	(1, 1, 0),
	(1, 2, 0),
	(2, 11, 0),
	(3, 21, 0),
	(4, 31, 0),
	(5, 41, 35);
GO
INSERT INTO PAYMENTS(reservationID, method, amount)
VALUES (1, 'qr', 35);
GO
