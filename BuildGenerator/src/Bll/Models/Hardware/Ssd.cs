using Bll.Models.Hardware.AbstractClasses;
using Bll.Models.Hardware.Interfaces;

namespace Bll.Models.Hardware;

public class Ssd : IHardware
{
    public double Price { get; set; }
    public string? Link { get; set; }
    public string? Manufacturer { get; set; }
    public string? Model { get; set; }

    public int Capacity { get; set; }

    public int ReadSpeed { get; set; }
    public int WriteSpeed { get; set; }
}