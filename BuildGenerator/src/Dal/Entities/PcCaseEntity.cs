namespace Dal.Entities;

public record PcCaseEntity(
    int Id,
    int HardwareId,
    string MotherboardFormat,
    int MaxPowerSupplyLength,
    int MaxGpuLength,
    int MaxAirHeight,
    int MaxAioFansCount
);