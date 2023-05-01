namespace Dal.Entities;

public record MotherboardEntity
{
    public int Id { get; init; }
    public int HardwareId { get; init; }
    public string TargetCpu { get; init; } = string.Empty;
    public string Format { get; init; } = string.Empty;
    public string Socket { get; init; } = string.Empty;
    public bool Ddr5 { get; init; }
}