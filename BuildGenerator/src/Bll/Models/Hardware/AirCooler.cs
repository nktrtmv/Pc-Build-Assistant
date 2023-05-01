using Bll.Models.Hardware.AbstractClasses;

namespace Bll.Models.Hardware;

public class AirCooler : Cooling
{
    public override double Price { get; set; }
    public override string? Link { get; set; }
    public override string? Manufacturer { get; set; }
    public override string? Socket { get; set; }
    public override int Tdp { get; set; }
    public override string? Model { get; set; }
}