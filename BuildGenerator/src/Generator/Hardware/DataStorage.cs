namespace Generator.Hardware;

public abstract class DataStorage : IHardware
{
    public abstract double Price { get; set; }
    public abstract string? Link { get; set; }
    public abstract string? Manufacturer { get; set; }
    
    public abstract int Capacity { get; set; }
}