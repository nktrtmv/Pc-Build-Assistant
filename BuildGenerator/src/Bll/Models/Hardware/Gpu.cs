namespace Bll.Models.Hardware;

public class Gpu : Abstractions.Hardware
{
    public double Price { get; set; }
    public string Link { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;


    public int Length { get; set; }
    public int RequiredPowerSupplyWattage { get; set; }

    public Gpu()
    {
        
    }
    
    public Gpu(double price, string link, string model, int length, int requiredPowerSupplyWattage)
    {
        Price = price;
        Link = link;
        Model = model;
        Length = length;
        RequiredPowerSupplyWattage = requiredPowerSupplyWattage;
    }
}