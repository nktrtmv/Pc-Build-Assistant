namespace Dal.Entities;

public record AirEntity
{
    public int Id { get; init; }
    public int HardwareId { get; init; }
    public int Tdp { get; init; }
    public int Height { get; init; }
}