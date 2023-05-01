namespace Dal.Entities;

public record GpuEntity
{
    public int Id { get; init; }
    public int HardwareId { get; init; }
    public int Length { get; init; }
    public int RequiredPowerSupplyWattage { get; init; }
}