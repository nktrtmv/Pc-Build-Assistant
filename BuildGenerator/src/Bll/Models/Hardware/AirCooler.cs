using Bll.Models.Hardware.Abstractions;

namespace Bll.Models.Hardware;

public class AirCooler : Cooling
{
    public sealed override double Price { get; set; }
    public sealed override string? Link { get; set; }
    public sealed override string? Model { get; set; }
    
    public int Tdp { get; set; }
    public int Height { get; set; }

    public AirCooler()
    {
        
    }
    
    public AirCooler(double price, string? link, string? model, int tdp, int height)
    {
        Price = price;
        Link = link;
        Model = model;
        Tdp = tdp;
        Height = height;
    }
}