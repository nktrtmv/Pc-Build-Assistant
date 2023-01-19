namespace Generator.Hardware;

public class Ram : IHardware
{
    public double Price { get; set; }
    public string? Link { get; set; }
    public string? Manufacturer { get; set; }
    
    public int TotalStorage { get; set; }
    public string? Type { get; set; }
    public int Count { get; set; }
    public int Frequency { get; set; }
}