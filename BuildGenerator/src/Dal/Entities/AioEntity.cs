namespace Dal.Entities;

public record AioEntity
{
    public int Id { get; init; }
    public int HardwareId { get; init; }
    public int FansCount { get; init; }
}