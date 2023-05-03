using Bll.Models.Hardware;
using Bll.Models.Hardware.Abstractions;

namespace Bll.Models.BuildTypes.Abstractions;

public abstract record PcBuild(
    Cpu Cpu,
    MotherBoard Motherboard,
    Case Case,
    Gpu? Gpu,
    Cooling Cooler,
    Ram Ram,
    Ssd Storage,
    PowerSupply PowerSupply
);