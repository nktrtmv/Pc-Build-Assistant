using Bll.Models.BuildTypes;
using Bll.Models.Hardware;
using Bll.Models.Hardware.Abstractions;
using Bll.RepositoryInterfaces;
using Bll.Services.Interfaces;

namespace Bll.Services;

public class BuildGeneratorService : IBuildGeneratorService
{
    private readonly IHardwareRepository _hardwareRepository;

    public BuildGeneratorService(IHardwareRepository hardwareRepository)
    {
        _hardwareRepository = hardwareRepository;
    }

    public async Task<GamePcBuild> GenerateGamePcBuild(int budget, CancellationToken token)
    {
        var pcParts = await _hardwareRepository.QueryHardware(token);

        var cpuList = pcParts.OfType<Cpu>().ToList();
        var motherboardList = pcParts.OfType<MotherBoard>().ToList();
        var caseList = pcParts.OfType<Case>().ToList();
        var gpuList = pcParts.OfType<Gpu>().ToList();
        var coolingList = pcParts.OfType<Cooling>().ToList();
        var ramList = pcParts.OfType<Ram>().ToList();
        var ssdList = pcParts.OfType<Ssd>().ToList();
        var psuList = pcParts.OfType<PowerSupply>().ToList();

        Gpu? gpu = null;
        Cpu? cpu = null;
        MotherBoard? motherboard = null;
        Case? @case = null;
        Cooling? cooling = null;
        Ram? ram = null;
        Ssd? ssd = null;
        PowerSupply? psu = null;

        double tempBudget = 0;


        // GPU
        var maxGpuBudget = budget * 0.52;
        var recommendedGpuBudget = budget < 120000 ? budget * 0.42 : budget * 0.47;
        double delta = 100000;
        foreach (var card in gpuList
                     .Where(card => card.Price < maxGpuBudget)
                     .Where(card => Math.Abs(card.Price - recommendedGpuBudget) < delta))
        {
            delta = Math.Abs(card.Price - recommendedGpuBudget);
            gpu = card;
        }

        if (gpu is null)
        {
            throw new Exception("No GPU found");
        }

        tempBudget += gpu.Price;


        // CPU
        var recommendedCpuBudget = budget * 0.15;
        var maxCpuBudget = budget * 0.23;
        delta = 100000;
        foreach (var cpuChip in cpuList
                     .Where(c => c.Model.ToLower().Contains("intel"))
                     .Where(cpuChip => cpuChip.Price < maxCpuBudget)
                     .Where(cpuCard => Math.Abs(cpuCard.Price - recommendedCpuBudget) < delta))
        {
            delta = Math.Abs(cpuChip.Price - recommendedCpuBudget);
            cpu = cpuChip;
        }

        if (cpu is null)
        {
            throw new Exception("No CPU found");
        }

        tempBudget += cpu.Price;


        // MOTHERBOARD
        var recommendedMbBudget = budget * 0.14;
        var maxMbBudget = budget * 0.23;
        delta = 100000;
        foreach (var mb in motherboardList
                     .Where(mb => mb.Price < maxMbBudget)
                     .Where(mb => Math.Abs(mb.Price - recommendedMbBudget) < delta)
                     .Where(mb => mb.Ddr5 == cpu.Ddr5)
                     .Where(mb =>
                         mb.TargetCpu.ToLower().Contains(cpu.Model.ToLower()) ||
                         cpu.Model.ToLower().Contains(mb.TargetCpu.ToLower()))
                )
        {
            delta = Math.Abs(mb.Price - recommendedMbBudget);
            motherboard = mb;
        }

        if (motherboard is null)
        {
            throw new Exception("No Motherboard found");
        }

        tempBudget += motherboard.Price;


        // RAM
        var maxRamBudget = budget * 0.15;
        var recommendedRamBudget = budget * 0.06;
        delta = 100000;
        foreach (var r in ramList
                     .OrderByDescending(x => x.Capacity)
                     .ThenByDescending(x => x.Frequency)
                     .Where(x => x.Ddr5 == motherboard.Ddr5 && x.Ddr5 == cpu.Ddr5)
                     .Where(x => x.Price < maxRamBudget)
                     .Where(x => Math.Abs(x.Price - recommendedRamBudget) < delta))
        {
            delta = Math.Abs(r.Price - recommendedRamBudget);
            ram = r;
        }

        if (ram is null)
        {
            throw new Exception("No RAM found");
        }

        tempBudget += ram.Price;

        // SSD
        var maxSsdBudget = budget * 0.12;
        var recommendedSsdBudget = budget * 0.06;
        delta = 100000;
        foreach (var s in ssdList
                     .OrderByDescending(x => x.Capacity)
                     .ThenByDescending(x => x.ReadSpeed)
                     .ThenByDescending(x => x.WriteSpeed)
                     .Where(x => x.Price < maxSsdBudget)
                     .Where(x => Math.Abs(x.Price - recommendedSsdBudget) < delta))
        {
            delta = Math.Abs(s.Price - recommendedSsdBudget);
            ssd = s;
        }

        if (ssd is null)
        {
            throw new Exception("No SSD found");
        }

        tempBudget += ssd.Price;

        // PSU
        var maxPsuBudget = budget < 100000 ? budget * 0.15 : budget * 0.1;
        var recommendedPsuBudget = budget * 0.05;
        delta = 100000;
        foreach (var power in psuList
                     .Where(power => power.Wattage >= gpu.RequiredPowerSupplyWattage)
                     .Where(power => power.Price < maxPsuBudget)
                     .Where(power => Math.Abs(power.Price - recommendedPsuBudget) < delta))
        {
            delta = Math.Abs(power.Price - recommendedPsuBudget);
            psu = power;
        }

        if (psu is null)
        {
            throw new Exception("No PSU found");
        }

        tempBudget += psu.Price;


        // COOLING
        var maxCoolingBudget = budget * 0.075;
        delta = 100000;
        if (cpu.Ddr5)
        {
            var recommendedCoolingBudget = budget * 0.05;
            foreach (var aio in coolingList
                         .OfType<Aio>()
                         .Where(x => cpu.Price > 30000 && x.FansCount == 3 || cpu.Price <= 30000 && x.FansCount == 2)
                         .Where(x => x.Price < maxCoolingBudget)
                         .Where(x => Math.Abs(x.Price - recommendedCoolingBudget) < delta))
            {
                delta = Math.Abs(aio.Price - recommendedCoolingBudget);
                cooling = aio;
            }
        }
        else
        {
            var recommendedCoolingBudget = budget * 0.03;
            foreach (var aio in coolingList
                         .OfType<AirCooler>()
                         .Where(x => x.Price < maxCoolingBudget)
                         .Where(x => Math.Abs(x.Price - recommendedCoolingBudget) < delta))
            {
                delta = Math.Abs(aio.Price - recommendedCoolingBudget);
                cooling = aio;
            }
        }

        if (cooling is null)
        {
            throw new Exception("No Cooling found");
        }

        tempBudget += cooling.Price;

        if (budget - tempBudget > 0.1 * budget)
        {
            recommendedGpuBudget = budget * 0.47;
            delta = 100000;
            foreach (var card in gpuList
                         .Where(card => card.Price < maxGpuBudget)
                         .Where(card => Math.Abs(card.Price - recommendedGpuBudget) < delta))
            {
                delta = Math.Abs(card.Price - recommendedGpuBudget);
                gpu = card;
            }
        }

        // CASE
        var minCaseBudget = budget * 0.02;
        var maxCaseBudget = budget * 0.08;
        var recommendedCaseBudget = budget * 0.045;
        delta = 100000;
        foreach (var c in caseList
                     .Where(x => x.MaxGpuLength >= gpu.Length)
                     .Where(x => x.MaxPowerSupplyLength > psu.Length)
                     .Where(x => x.MotherBoardFormat == motherboard.Format)
                     .Where(x => x.Price > minCaseBudget && x.Price < maxCaseBudget)
                     .Where(x => Math.Abs(x.Price - recommendedCaseBudget) < delta))
        {
            delta = Math.Abs(c.Price - recommendedCaseBudget);
            @case = c;
        }

        if (@case is null)
        {
            throw new Exception("No Case found");
        }

        var result = new GamePcBuild(
            Cpu: cpu,
            Motherboard: motherboard,
            Case: @case,
            Gpu: gpu,
            Cooler: cooling,
            Ram: ram,
            Storage: ssd,
            PowerSupply: psu
        );

        return result;
    }

    public async Task<GraphicsPcBuild> GenerateGraphicsPcBuild(int budget, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<ItPcBuild> GenerateItPcBuild(int budget, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<OfficePcBuild> GenerateOfficePcBuild(int budget, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}