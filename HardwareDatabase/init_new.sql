TCREATE TABLE Hardware
(
    Id SERIAL PRIMARY KEY,
    Model TEXT NOT NULL,
    Price INTEGER NOT NULL,
    Link TEXT NOT NULL
);

CREATE TABLE CPU
(
    Id SERIAL PRIMARY KEY,
    CpuId INTEGER,
    Manufacturer TEXT NOT NULL,
    RamType INTEGER,
    IntegratedGraphics INTEGER,
    TDP INTEGER,
    Socket TEXT NOT NULL,
    FOREIGN KEY (CpuId) REFERENCES Hardware (Id)
);

CREATE TABLE GPU
(
    Id SERIAL PRIMARY KEY,
    GpuId INTEGER,
    GpuLength DOUBLE PRECISION,
    GpuWidth DOUBLE PRECISION,
    GpuHeight DOUBLE PRECISION,
    FOREIGN KEY (GpuId) REFERENCES Hardware (Id)
);

CREATE TABLE AIO
(
    Id SERIAL PRIMARY KEY,
    AioId INTEGER,
    Socket TEXT NOT NULL,
    TDP INTEGER,
    FansCount INTEGER,
    FOREIGN KEY (AioId) REFERENCES Hardware (Id)
);

CREATE TABLE AIR
(
    Id SERIAL PRIMARY KEY,
    AirId INTEGER,
    Socket TEXT NOT NULL,
    TDP INTEGER,
    FOREIGN KEY (AirId) REFERENCES Hardware (Id)
);

CREATE TABLE CASE
(
    Id SERIAL PRIMARY KEY,
    CaseId INTEGER,
    PowerSupplyFormat TEXT NOT NULL,
    MotherBoardFormat TEXT NOT NULL,
    FOREIGN KEY (CaseId) REFERENCES Hardware (Id)
);

CREATE TABLE SSD
(
    Id SERIAL PRIMARY KEY,
    SsdId INTEGER,
    Capacity INTEGER, 
    ReadSpeed INTEGER,
    WriteSpeed INTEGER,
    FOREIGN KEY (SsdId) REFERENCES Hardware (Id)
);

CREATE TABLE HDD
(
    Id SERIAL PRIMARY KEY,
    HddId INTEGER,
    Capacity INTEGER,
    FOREIGN KEY (HddId) REFERENCES Hardware (Id)
);

CREATE TABLE MB
(
    Id SERIAL PRIMARY KEY,
    MbId INTEGER,
    TargetCpu TEXT NOT NULL,
    Socket TEXT NOT NULL,
    RamTypeR INTEGER,
    Format TEXT NOT NULL,
    FOREIGN KEY (MbId) REFERENCES Hardware (Id)
);

CREATE TABLE POWER
(
    Id SERIAL PRIMARY KEY,
    PowerId INTEGER,
    Wattage INTEGER,
    FormFactor TEXT NOT NULL,
    Certification TEXT NOT NULL,
    IsModular INTEGER,
    FOREIGN KEY (PowerId) REFERENCES Hardware (Id)
);

CREATE TABLE RAM
(
    Id SERIAL PRIMARY KEY,
    RamId INTEGER,
    DDRType INTEGER,
    Frequency INTEGER,
    Capacity INTEGER,
    Count INTEGER,
    FOREIGN KEY (RamId) REFERENCES Hardware (Id)
);