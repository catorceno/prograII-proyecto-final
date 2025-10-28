USE TeatroTickets2;
GO

-- AGREGAR UN TEATRO
-- crear usuario
INSERT INTO USERS(email, [password], rol)
VALUES ('theater@gmail', '12345', 'theater');
GO
-- formulario con los datos del teatro
INSERT INTO THEATERS(userID, [name], direction, phone, email, capacity)
VALUES (1, 'theater1', 'my direction', NULL, NULL, 10);
GO

-- mapa del teatro
INSERT INTO SEATING_AREAS(theaterID, [name], capacity)
VALUES (1, 'platea', 6), (1, 'anfiteatro', 4);
GO
INSERT INTO BUTACAS(seatingAreaID, [row], number)
VALUES
	(1, 'A', 1),
	(1, 'A', 3),
	(1, 'A', 5),
	(1, 'B', 2),
	(1, 'B', 4),
	(1, 'B', 6),
	(1, 'A', 1),
	(1, 'A', 3),
	(1, 'B', 2),
	(1, 'B', 4);
GO

-- AGREGAR UN EVENTO, desde el teatro
-- crear evento
INSERT INTO [EVENTS](theaterID, title, [description], category, [datetime], duration, [state])
VALUES 
	(1, 'some event', 'some description', 'music', GETDATE(), 180, 'presale'),
	(1, 'some event', 'some description', 'music', GETDATE(), 180, 'presale');
GO

-- 