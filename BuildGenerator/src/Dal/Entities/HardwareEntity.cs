namespace Dal.Entities;

public record HardwareEntity(
    int Id,
    int ProductType,
    string Model,
    double Price,
    string Link
);