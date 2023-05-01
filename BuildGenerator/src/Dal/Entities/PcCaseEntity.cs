namespace Dal.Entities;

public record PcCaseEntity
{
    public int Id { get; init; }
    public int HardwareId { get; init; }
    public string MotherboardFormat { get; init; } = string.Empty;
    public int MaxPowerSupplyLength { get; init; }
    public int MaxGpuLength { get; init; }
    public int MaxAirHeight { get; init; }
    public int MaxAioFansCount { get; init; }
}