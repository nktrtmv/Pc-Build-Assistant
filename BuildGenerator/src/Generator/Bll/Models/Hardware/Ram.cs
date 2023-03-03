namespace Generator.Hardware;

public class Ram : IHardware
{
    public double Price { get; set; }
    public string? Link { get; set; }
    public string? Manufacturer { get; set; }
    public string? Model { get; set; }

    public int Capacity { get; set; }
    public int DdrType { get; set; }
    public int Count { get; set; }
    public int Frequency { get; set; }
}
