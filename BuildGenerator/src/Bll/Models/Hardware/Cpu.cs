namespace Bll.Models.Hardware;

public class Cpu : Abstractions.Hardware
{
    public double Price { get; set; }
    public string Link { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;

    public string Manufacturer { get; set; } = string.Empty;
    public bool Ddr5 { get; set; }
    public bool IntegratedGraphics { get; set; }
    public int Tdp { get; set; }
    public string Socket { get; set; } = string.Empty;

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