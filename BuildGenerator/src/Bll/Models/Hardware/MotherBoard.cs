namespace Bll.Models.Hardware;

public class MotherBoard : Abstractions.Hardware
{
    public double Price { get; set; }
    public string Link { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;

    public string TargetCpu { get; set; } = string.Empty;
    public string Format { get; set; } = string.Empty;
    public string Socket { get; set; } = string.Empty;
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