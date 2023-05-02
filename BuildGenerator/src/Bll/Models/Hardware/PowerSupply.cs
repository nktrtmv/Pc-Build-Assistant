namespace Bll.Models.Hardware;

public class PowerSupply : Abstractions.Hardware
{
    public double Price { get; set; }
    public string Link { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;

    public int Wattage { get; set; }
    public string Certification { get; set; } = string.Empty;
    public bool IsModular { get; set; }
    public int Length { get; set; }

    public PowerSupply()
    {
        
    }
    
    public PowerSupply(double price, string link, string model, int wattage, string certification, bool isModular, int length)
    {
        Price = price;
        Link = link;
        Model = model;
        Wattage = wattage;
        Certification = certification;
        IsModular = isModular;
        Length = length;
    }
}