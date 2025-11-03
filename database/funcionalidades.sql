USE TeatroTickets5
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
INSERT INTO [EVENTS](theaterID, performerID, title, description, playbillPDF, category, type, state)
VALUES (1, 10, 'Festival Internacional de Danza Contemporánea', 'festival', NULL, 'dance', 'festival', 'published');
GO
INSERT INTO PLAYS(eventID, performerID, title, description, duration)
VALUES 
	(1, 10, 'sempiterna', 'description1', 60),
	(1, 11, 'vuelta', 'description2', 60),
	(1, 12, 'acero', 'description3', 60),
	(1, 13, 'acostumbrarse pero puede cambiar', 'description4', 60),
	(1, 14, 'camila mia', 'description5', 60);
GO
INSERT INTO PERFORMANCES(datetime, state)
VALUES
	('2025-12-1 19:00:00', 'onsale'),
	('2025-12-2 19:00:00', 'onsale'),
	('2025-12-3 19:00:00', 'onsale'),
	('2025-12-4 19:00:00', 'onsale'),
	('2025-12-5 19:00:00', 'onsale');
GO
INSERT INTO PLAYS_PERFORMANCE(playID, performanceID)
VALUES
	(1, 1),
	(2, 2),
	(3, 3),
	(4, 4),
	(5, 5);
GO

-- crear evento - categoria: show
INSERT INTO [EVENTS]()
VALUES ();
GO
INSERT INTO PLAYS()
VALUES ();
GO
INSERT INTO PERFORMANCES()
VALUES ();
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
select * from PERFORMANCES
select * from PRICE_ZONES
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

---------------------------- COMPRAR TICKETS
INSERT INTO RESERVATIONS(eventID, total)
VALUES (1, 35);
GO
INSERT INTO TICKETS(reservationID, priceZoneSeatID, price)
VALUES
	(1, 1, 0),
	(1, 11, 0),
	(1, 21, 0),
	(1, 31, 0),
	(1, 41, 35),
	(1, 2, 0);
GO
INSERT INTO PAYMENTS(reservationID, method, amount)
VALUES (1, 'qr', 35);
GO
