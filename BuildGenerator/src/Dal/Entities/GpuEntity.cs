namespace Dal.Entities;

public record GpuEntity(
    int Id,
    int HardwareId,
    int Length,
    int RequiredPowerSupplyWattage
);