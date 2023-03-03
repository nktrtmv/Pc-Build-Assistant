namespace Generator.Hardware;

public class Ssd : DataStorage
{
    public override double Price { get; set; }
    public override string? Link { get; set; }
    public override string? Manufacturer { get; set; }
    public override string? Model { get; set; }

    public override int Capacity { get; set; }
    
    public (int, int) Speed { get; set; }
}