namespace Generator.Hardware;

public class PowerSupply : IHardware
{
    public double Price { get; set; }
    public string? Link { get; set; }
    public string? Manufacturer { get; set; }
    public string? Model { get; set; }

    public int Wattage { get; set; }
    public bool IsModular { get; set; }
    public string? –°ertification { get; set; }
    public string? FormFactor { get; set; }
}