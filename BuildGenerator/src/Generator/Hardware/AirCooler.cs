namespace Generator.Hardware;

public class AirCooler : Cooling
{
    public override double Price { get; set; }
    public override string? Link { get; set; }
    public override string? Manufacturer { get; set; }
    public override string? Socket { get; set; }
    public override int Tdp { get; set; }
    
    public int HeatPipesCount { get; set; }
    public int Height { get; set; }
}