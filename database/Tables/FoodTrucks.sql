﻿CREATE TABLE dbo.FoodTrucks
(
	FoodTruckId      INT IDENTITY(1,1)    NOT NULL,
	TruckName        VARCHAR(50)          NOT NULL,
	Description      VARCHAR(512)         NOT NULL,
	Website          VARCHAR(100)         NULL,
	RowValidFrom     DATETIME2(3) GENERATED ALWAYS AS ROW START,
    RowValidTo       DATETIME2(3) GENERATED ALWAYS AS ROW END,
	PERIOD FOR SYSTEM_TIME (RowValidFrom, RowValidTo),
	CONSTRAINT PK_FoodTrucks
	    PRIMARY KEY (FoodTruckId)
)
WITH (SYSTEM_VERSIONING = ON
    (HISTORY_TABLE = dbo.FoodTrucksHistory));

