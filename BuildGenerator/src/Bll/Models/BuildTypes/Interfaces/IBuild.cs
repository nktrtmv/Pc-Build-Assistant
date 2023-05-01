using Bll.Models.Hardware;
using Bll.Models.Hardware.AbstractClasses;

namespace Bll.Models.BuildTypes.Interfaces;

public interface IBuild
{
    Cpu Cpu { get; }
    MotherBoard Motherboard { get; }
    Case Case { get; }
    Gpu? Gpu { get; }
    Cooling Cooler { get; }
    Ram Ram { get; }
    Ssd Storage { get; }
    PowerSupply PowerSupply { get; }
    
    void Generate();
}