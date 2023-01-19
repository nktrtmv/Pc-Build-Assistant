namespace Generator.Hardware;

public class Case : IHardware
{
    public double Price { get; set; }
    public string? Link { get; set; }
    public string? Manufacturer { get; set; }
    
    public string? PowerSupplyFormat { get; set; }
    public string? MotherBoardFormat { get; set; }
}