CREATE TABLE Rooms (
    RoomId int NOT NULL PRIMARY KEY,
    RoomCode varchar(20),
);

CREATE TABLE Items (
    ItemId int NOT NULL PRIMARY KEY,
    Name nvarchar(50) NOT NULL,
	RoomId int,
    CONSTRAINT FK_RoomId FOREIGN KEY (RoomId)
    REFERENCES Rooms(RoomId)
);