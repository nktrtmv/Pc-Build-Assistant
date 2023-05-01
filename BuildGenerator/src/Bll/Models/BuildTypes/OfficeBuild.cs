using Bll.Models.BuildTypes.Interfaces;
using Bll.Models.Hardware;
using Bll.Models.Hardware.AbstractClasses;

namespace Bll.Models.BuildTypes;

public class OfficeBuild : IBuild
{
    public Cpu Cpu { get; }
    
    public MotherBoard Motherboard { get; }
    
    public Case Case { get; }
    
    public Gpu? Gpu { get; }
    
    public Cooling Cooler { get; }
    
    public Ram Ram { get; }
    
    public Ssd Storage { get; }
    
    public PowerSupply PowerSupply { get; }

    public OfficeBuild(int budget)
    {
        Cpu = new Cpu();
        Motherboard = new MotherBoard();
        Case = new Case();
        Gpu = new Gpu();
        Cooler = new AirCooler();
        Ram = new Ram();
        Storage = new Ssd();
        PowerSupply = new PowerSupply();
    }
    
    public void Generate()
    {
        throw new NotImplementedException();
    }
}