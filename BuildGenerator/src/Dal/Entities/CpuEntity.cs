namespace Dal.Entities;

public record CpuEntity(
    int Id,
    int HardwareId,
    string Manufacturer,
    bool Ddr5,
    bool IntegratedGraphics,
    int Tdp,
    string Socket
);