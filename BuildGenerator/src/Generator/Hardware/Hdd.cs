namespace Generator.Hardware;

public class Hdd : DataStorage
{
    public override double Price { get; set; }
    public override string? Link { get; set; }
    public override string? Manufacturer { get; set; }
    
    public override int Capacity { get; set; }
    public int Rpm { get; set; }
}