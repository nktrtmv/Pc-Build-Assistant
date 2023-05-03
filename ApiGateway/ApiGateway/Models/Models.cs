using System.Text.Json.Serialization;

namespace ApiGateway.Models;

public enum BuildType
{
    GameBuild,
    GraphicsBuild,
    ItBuild,
    OfficeBuild
}

public record BuildGenerationRequest(
    BuildType Type, 
    int Budget);

public class BuildGenerationResponse{
    [JsonPropertyName("pc_build")]
    public PcBuild PcBuild { get; init; }
    
    [JsonPropertyName("total_price")]
    public double TotalPrice { get; init; }
    
    public BuildGenerationResponse(PcBuild pcBuild, double totalPrice)
    {
        PcBuild = pcBuild;
        TotalPrice = totalPrice;
    }
}

public record GenerateBuildResponse(
    PcBuild PcBuild,
    double TotalPrice,
    Guid Id);

public record BuildEntity(
    PcBuild PcBuild,
    Guid Id);

public class Hardware{
    [JsonPropertyName("price")]
    public double Price { get; init; }
    
    [JsonPropertyName("link")]
    public string Link { get; init; }
    
    [JsonPropertyName("model")]
    public string Model { get; init; }
    
    public Hardware(double price, string link, string model)
    {
        Price = price;
        Link = link;
        Model = model;
    }
    
    public Hardware()
    {
        Price = 0;
        Link = "";
        Model = "";
    }
}

public class PcBuild
{
    [JsonPropertyName("cpu")]
    public Hardware Cpu { get; init; }
    
    [JsonPropertyName("motherboard")]
    public Hardware Motherboard { get; init; }
    
    [JsonPropertyName("case")]
    public Hardware Case { get; init; }
    
    [JsonPropertyName("gpu")]
    public Hardware? Gpu { get; init; }
    
    [JsonPropertyName("cooler")]
    public Hardware Cooler { get; init; }
    
    [JsonPropertyName("ram")]
    public Hardware Ram { get; init; }
    
    [JsonPropertyName("storage")]
    public Hardware Storage { get; init; }
    
    [JsonPropertyName("power_supply")]
    public Hardware PowerSupply { get; init; }
    
    public PcBuild(
        Hardware cpu, 
        Hardware motherboard, 
        Hardware @case, 
        Hardware? gpu, 
        Hardware cooler, 
        Hardware ram, 
        Hardware storage, 
        Hardware powerSupply)
    {
        Cpu = cpu;
        Motherboard = motherboard;
        Case = @case;
        Gpu = gpu;
        Cooler = cooler;
        Ram = ram;
        Storage = storage;
        PowerSupply = powerSupply;
    }
}