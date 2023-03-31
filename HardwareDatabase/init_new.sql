CREATE TABLE Hardware
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
    DDR5 INTEGER,
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
    RequiredPowerSupplyWattage INTEGER,
    FOREIGN KEY (GpuId) REFERENCES Hardware (Id)
);

CREATE TABLE AIO
(
    Id SERIAL PRIMARY KEY,
    AioId INTEGER,
    FansCount INTEGER,
    FOREIGN KEY (AioId) REFERENCES Hardware (Id)
);

CREATE TABLE AIR
(
    Id SERIAL PRIMARY KEY,
    AirId INTEGER,
    TDP INTEGER,
    Height INTEGER,
    FOREIGN KEY (AirId) REFERENCES Hardware (Id)
);

CREATE TABLE CASE
(
    Id SERIAL PRIMARY KEY,
    CaseId INTEGER,
    MotherBoardFormat TEXT NOT NULL,
    MaxPowerSupplyLength INTEGER,
    MaxGpuLength INTEGER,
    MaxAirHeight INTEGER,
    MaxAioSize INTEGER,
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

CREATE TABLE MB
(
    Id SERIAL PRIMARY KEY,
    MbId INTEGER,
    TargetCpu TEXT NOT NULL,
    Format TEXT NOT NULL,
    Socket TEXT NOT NULL,
    RamType INTEGER,
    FOREIGN KEY (MbId) REFERENCES Hardware (Id)
);

CREATE TABLE POWERSUPPLY
(
    Id SERIAL PRIMARY KEY,
    PowerSupplyId INTEGER,
    Wattage INTEGER,
    Certification TEXT NOT NULL,
    IsModular INTEGER,
    MaxPowerSupplyLength INTEGER,
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