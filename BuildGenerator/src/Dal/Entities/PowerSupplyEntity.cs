namespace Dal.Entities;

public record PowerSupplyEntity(
    int Id,
    int HardwareId,
    int Wattage,
    string Certification,
    bool IsModular,
    int Length
);