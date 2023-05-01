using Bll.Models.Hardware.Interfaces;

namespace Bll.Models.Hardware.AbstractClasses;

public abstract class Cooling : IHardware
{
    public abstract double Price { get; set; }
    public abstract string? Link { get; set; }
    public abstract string? Model { get; set; }
}