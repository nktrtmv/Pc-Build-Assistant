namespace Dal.Entities;

public record RamEntity
{
    public int Id { get; init; }
    public int HardwareId { get; init; }
    public bool Ddr5 { get; init; }
    public int Frequency { get; init; }
    public int Capacity { get; init; }
    public int Count { get; init; }
}