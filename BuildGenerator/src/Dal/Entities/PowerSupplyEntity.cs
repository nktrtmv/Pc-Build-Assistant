namespace Dal.Entities;

public record PowerSupplyEntity
{
    public int Id { get; init; }
    public int HardwareId { get; init; }
    public int Wattage { get; init; }
    public string Certification { get; init; } = string.Empty;
    public bool IsModular { get; init; }
    public int Length { get; init; }
}