namespace Dal.Entities;

public record HardwareEntity
{
    public int Id { get; init; }
    public int ProductType { get; init; }
    public string Model { get; init; } = string.Empty;
    public double Price { get; init; }
    public string Link { get; init; } = string.Empty;
}