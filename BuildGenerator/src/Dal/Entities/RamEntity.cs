namespace Dal.Entities;

public record RamEntity(
    int Id,
    int HardwareId,
    bool Ddr5,
    int Frequency,
    int Capacity,
    int Count
);