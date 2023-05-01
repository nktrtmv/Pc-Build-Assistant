using Bll.Models.Hardware.Interfaces;

namespace Bll.Models.Hardware;

public class Case : IHardware
{
    public double Price { get; set; }
    public string? Link { get; set; }
    public string? Model { get; set; }

    public string? MotherBoardFormat { get; set; }
    public int? MaxPowerSupplyLength { get; set; }
    public int? MaxGpuLength { get; set; }
    public int? MaxAirHeight { get; set; }
    public int? MaxAioFansCount { get; set; }

    public Case()
    {
        
    }
    
    public Case(double price, string link, string model, string motherboardFormat, int maxPowerSupplyLength,
        int maxGpuLength, int maxAirHeight, int maxAioFansCount)
    {
        Price = price;
        Link = link;
        Model = model;
        MotherBoardFormat = motherboardFormat;
        MaxPowerSupplyLength = maxPowerSupplyLength;
        MaxGpuLength = maxGpuLength;
        MaxAirHeight = maxAirHeight;
        MaxAioFansCount = maxAioFansCount;
    }
}