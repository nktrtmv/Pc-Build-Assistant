namespace Generator.Hardware;

public class MotherBoard : IHardware
{
    public double Price { get; set; }
    public string? Link { get; set; }
    public string? Manufacturer { get; set; }
    
    public string? Socket { get; set; }
    public string? RamType { get; set; }
    public int RamSlotsCount { get; set; }
    public string? Format { get; set; }
}