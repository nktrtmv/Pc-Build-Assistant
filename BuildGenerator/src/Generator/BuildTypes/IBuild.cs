using Generator.Hardware;

namespace Generator.BuildTypes;

public interface IBuild
{
    Cpu Cpu { get; }
    MotherBoard Motherboard { get; }
    Case Case { get; }
    Gpu? Gpu { get; }
    Cooling Cooler { get; }
    Ram Ram { get; }
    DataStorage Drive { get; }
    PowerSupply PowerSupply { get; }
    
    void Generate();
}