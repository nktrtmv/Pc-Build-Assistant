namespace Generator.Hardware;

public abstract class Cooling : IHardware
{
    public abstract double Price { get; set; }
    public abstract string? Link { get; set; }
    public abstract string? Manufacturer { get; set; }
    
    public abstract string? Socket { get; set; }
    
    public abstract int Tdp { get; set; }
}