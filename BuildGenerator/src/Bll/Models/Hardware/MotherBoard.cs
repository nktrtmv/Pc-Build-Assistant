using Bll.Models.Hardware.Interfaces;

namespace Bll.Models.Hardware;

public class MotherBoard : IHardware
{
    public double Price { get; set; }
    public string? Link { get; set; }
    public string? Model { get; set; }

    public string? TargetCpu { get; set; }
    public string? Format { get; set; }
    public string? Socket { get; set; }
    public bool Ddr5 { get; set; }

    public MotherBoard()
    {
        
    }
    
    public MotherBoard(double price, string link, string model, string targetCpu, string format, string socket, bool ddr5)
    {
        Price = price;
        Link = link;
        Model = model;
        TargetCpu = targetCpu;
        Format = format;
        Socket = socket;
        Ddr5 = ddr5;
    }
}