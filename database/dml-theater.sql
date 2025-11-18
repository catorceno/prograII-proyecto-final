USE TeatroTickets7
GO

INSERT INTO USERS(email, password, rol)
VALUES ('theater@email', '123', 'theater');
GO
INSERT INTO THEATERS(userID, name, address, capacity, contact)
VALUES (1, 'theater1', 'address1', 10, 'contact1');
GO
INSERT INTO SCHEDULES(theaterID, [day], openingTime, closingTime)
VALUES
	(1, 'friday', '17:00:00', '21:00:00'),
	(1, 'saturday', '17:00:00', '23:00:00'),
	(1, 'sunday', '17:00:00', '23:00:00');
GO
INSERT INTO [ROWS](theaterID, name)
VALUES
	(1, 'A'),
	(1, 'B'),
	(1, 'C'),
	(1, 'D'),
	(1, 'E'),
	(1, 'F'),
	(1, 'G'),
	(1, 'H'),
	(1, 'I'),
	(1, 'J'), -- 10
	(1, 'K'),
	(1, 'L'),
	(1, 'M'),
	(1, 'N'),
	(1, 'O'),
	(1, 'P'); -- 16
GO
INSERT INTO SEATS(rowID, number, side, [column])
VALUES
	(1, 16, 'L', 1),
	(1, 14, 'L', 2),
	(1, 12, 'L', 3),
	(1, 10, 'L', 4),
	(1, 8, 'L', 5),
	(1, 6, 'L', 6),
	(1, 4, 'L', 7),
	(1, 2, 'L', 8),
	(1, 1, 'R', 9),
	(1, 3, 'R', 10),
	(1, 5, 'R', 11),
	(1, 7, 'R', 12),
	(1, 9, 'R', 13),
	(1, 11, 'R', 14),
	(1, 13, 'R', 15),
	(1, 15, 'R', 16), -- A
	(2, 16, 'L', 1),
	(2, 14, 'L', 2),
	(2, 12, 'L', 3),
	(2, 10, 'L', 4),
	(2, 8, 'L', 5),
	(2, 6, 'L', 6),
	(2, 4, 'L', 7),
	(2, 2, 'L', 8),
	(2, 1, 'R', 9),
	(2, 3, 'R', 10),
	(2, 5, 'R', 11),
	(2, 7, 'R', 12),
	(2, 9, 'R', 13),
	(2, 11, 'R', 14),
	(2, 13, 'R', 15),
	(2, 15, 'R', 16), -- B
	(3, 16, 'L', 1),
	(3, 14, 'L', 2),
	(3, 12, 'L', 3),
	(3, 10, 'L', 4),
	(3, 8, 'L', 5),
	(3, 6, 'L', 6),
	(3, 4, 'L', 7),
	(3, 2, 'L', 8),
	(3, 1, 'R', 9),
	(3, 3, 'R', 10),
	(3, 5, 'R', 11),
	(3, 7, 'R', 12),
	(3, 9, 'R', 13),
	(3, 11, 'R', 14),
	(3, 13, 'R', 15),
	(3, 15, 'R', 16); -- C
GO
	