namespace Bll.Models.Hardware.Abstractions;

public abstract class Cooling : Abstractions.Hardware
{
    public abstract double Price { get; set; }
    public abstract string Link { get; set; } 
    public abstract string Model { get; set; }
}