namespace Generator.Hardware;

public class Gpu : IHardware
{
    public double Price { get; set; }
    public string? Link { get; set; }
    public string? Manufacturer { get; set; }
    
    /// <summary>
    /// Length, Width, Height
    /// </summary>
    public (double, double, double) Size { get; set; }
}