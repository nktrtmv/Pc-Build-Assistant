namespace Dal.Entities;

public record SsdEntity
{
    public int Id { get; init; }
    public int HardwareId { get; init; }
    public int Capacity { get; init; }
    public int ReadSpeed { get; init; }
    public int WriteSpeed { get; init; }
}