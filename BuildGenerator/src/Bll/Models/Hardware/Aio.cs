using Bll.Models.Hardware.Abstractions;

namespace Bll.Models.Hardware;

public class Aio : Cooling
{
    public sealed override double Price { get; set; }
    public sealed override string Link { get; set; } = string.Empty;
    public sealed override string Model { get; set; } = string.Empty;
    
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