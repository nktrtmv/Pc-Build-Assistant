using Generator.Bll.Models.Hardware.Interfaces;

namespace Generator.Bll.Models.Hardware;

public class Gpu : IHardware
{
    public double Price { get; set; }
    public string? Link { get; set; }
    public string? Manufacturer { get; set; }
    public string? Model { get; set; }


    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
}