namespace Dal.Entities;

public record SsdEntity(
    int Id,
    int HardwareId,
    int Capacity,
    int ReadSpeed,
    int WriteSpeed
);