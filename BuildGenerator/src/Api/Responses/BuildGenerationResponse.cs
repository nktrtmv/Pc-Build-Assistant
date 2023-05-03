namespace Generator.Responses;

public record BuildGenerationResponse(
    PcBuild PcBuild,
    double TotalPrice
);

public record Hardware(
    double Price,
    string Link,
    string Model
);

public record PcBuild(
    Hardware Cpu,
    Hardware Motherboard,
    Hardware Case,
    Hardware? Gpu,
    Hardware Cooler,
    Hardware Ram,
    Hardware Storage,
    Hardware PowerSupply
)
{
    public double Price()
    {
        return Cpu.Price + Motherboard.Price + Case.Price + Cooler.Price + Ram.Price + Storage.Price +
               PowerSupply.Price + (Gpu?.Price ?? 0);
    }
}