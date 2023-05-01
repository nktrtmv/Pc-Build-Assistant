using Bll.Models.BuildTypes.Abstractions;
using Bll.Models.Hardware;
using Bll.Models.Hardware.Abstractions;

namespace Bll.Models.BuildTypes;

public record GraphicsPcBuild(
    Cpu Cpu,
    MotherBoard Motherboard,
    Case Case,
    Gpu Gpu,
    Cooling Cooler,
    Ram Ram,
    Ssd Storage,
    PowerSupply PowerSupply
) : PcBuild(Cpu, Motherboard, Case, Gpu, Cooler, Ram, Storage, PowerSupply);