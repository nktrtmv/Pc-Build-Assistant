using Generator.Bll.Models.Hardware.Interfaces;

namespace Generator.Bll.Models.Hardware;

public class Cpu : IHardware
{
    public double Price { get; set; }
    public string? Link { get; set; }
    public string? Manufacturer { get; set; }
    public string? Model { get; set; }

    public string? Socket { get; set; }
    public int RamType { get; set; }
    public bool IntegratedGraphics { get; set; }
    public int Tdp { get; set; }
}