namespace Dal.Entities;

public record CpuEntity
{
    public int Id { get; init; }
    public int HardwareId { get; init; }
    public string Manufacturer { get; init; } = string.Empty;
    public bool Ddr5 { get; init; }
    public bool IntegratedGraphics { get; init; }
    public int Tdp { get; init; }
    public string Socket { get; init; } = string.Empty;
}