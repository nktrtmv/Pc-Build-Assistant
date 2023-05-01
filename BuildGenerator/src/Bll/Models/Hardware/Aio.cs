using Bll.Models.Hardware.AbstractClasses;

namespace Bll.Models.Hardware;

public class Aio : Cooling
{
    public sealed override double Price { get; set; }
    public sealed override string? Link { get; set; }
    public sealed override string? Model { get; set; }
    
    public int FansCount { get; set; }

    public Aio()
    {
        
    }

    public Aio(double price, string link, string model, int fansCount)
    {
        Price = price;
        Link = link;
        Model = model;
        FansCount = fansCount;
    }
}