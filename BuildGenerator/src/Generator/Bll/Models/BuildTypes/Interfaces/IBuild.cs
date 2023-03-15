using Generator.Bll.Models.Hardware;
using Generator.Bll.Models.Hardware.AbstractClasses;

namespace Generator.Bll.Models.BuildTypes.Interfaces;

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