CREATE TABLE Hardware
(
    Id SERIAL PRIMARY KEY,
    HardwareType CHARACTER VARYING(10) NOT NULL
);

CREATE TABLE HardwareInfo
(
    Id SERIAL PRIMARY KEY,
    HardwareId INTEGER,
    HardwareName TEXT NOT NULL,
    Price INTEGER NOT NULL,
    Link TEXT NOT NULL,
    HardwareInfo JSON NOT NULL,
    FOREIGN KEY (HardwareId) REFERENCES Hardware (Id)
);