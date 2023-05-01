namespace Dal.Entities;

public record MotherboardEntity(
    int Id,
    int HardwareId,
    string TargetCpu,
    string Format,
    string Socket,
    bool Ddr5
);