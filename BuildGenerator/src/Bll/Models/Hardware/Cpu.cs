using Bll.Models.Hardware.Interfaces;

namespace Bll.Models.Hardware;

public class Cpu : IHardware
{
    public double Price { get; set; }
    public string? Link { get; set; }
    public string? Model { get; set; }

    public string? Manufacturer { get; set; }
    public bool Ddr5 { get; set; }
    public bool IntegratedGraphics { get; set; }
    public int Tdp { get; set; }
    public string? Socket { get; set; }

    public Cpu()
    {
        
    }
    
    public Cpu(double price, string link, string model, string manufacturer, bool ddr5, bool integratedGraphics, int tdp, string socket)
    {
        Price = price;
        Link = link;
        Model = model;
        Manufacturer = manufacturer;
        Ddr5 = ddr5;
        IntegratedGraphics = integratedGraphics;
        Tdp = tdp;
        Socket = socket;
    }
}