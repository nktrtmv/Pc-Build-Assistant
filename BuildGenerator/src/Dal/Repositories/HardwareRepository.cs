using Bll.Models.Hardware;
using Bll.Models.Hardware.Interfaces;
using Dal.Entities;
using Dal.Enums;
using Dal.Repositories.Interfaces;
using Dal.Settings;
using Dapper;
using Microsoft.Extensions.Options;

namespace Dal.Repositories;

public class HardwareRepository : BaseRepository, IHardwareRepository
{
    public HardwareRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    public async Task<IEnumerable<IHardware>> QueryHardware(CancellationToken token)
    {
        await using var connection = await GetAndOpenConnection();
        const string hardwareSqlQuery = "select id, product_type, model, price, link from hardware";

        var hardware = new List<IHardware>(capacity: 200);
        
        var hardwareQuery = await connection.QueryAsync<HardwareEntity>(
            new CommandDefinition(
                hardwareSqlQuery,
                cancellationToken: token));

        foreach (var part in hardwareQuery)
        {
            switch (part.ProductType)
            {
                case (int)HardwareTypes.Aio:
                    const string aioSqlQuery = "select id, hardware_id, fans_count from aio where hardware_id = @HardwareId";
                    
                    var aioSqlParams = new
                    {
                        HardwareId = part.Id,
                    };
                    
                    var aio = (await connection.QueryAsync<AioEntity>(
                        new CommandDefinition(
                            aioSqlQuery,
                            aioSqlParams,
                            cancellationToken: token)))
                        .First();
                    
                    hardware.Add(new Aio(
                        price: part.Price, 
                        link: part.Link,
                        model: part.Model,
                        fansCount: aio.FansCount));
                    break;
                
                case (int)HardwareTypes.Air:
                    const string airSqlQuery = "select id, hardware_id, tdp, height from air where hardware_id = @HardwareId";
                    
                    var airSqlParams = new
                    {
                        HardwareId = part.Id,
                    };
                    
                    var air = (await connection.QueryAsync<AirEntity>(
                            new CommandDefinition(
                                airSqlQuery,
                                airSqlParams,
                                cancellationToken: token)))
                        .First();
                    
                    hardware.Add(new AirCooler(
                        price: part.Price, 
                        link: part.Link,
                        model: part.Model,
                        tdp: air.Tdp,
                        height: air.Height));
                    break;
                
                case (int)HardwareTypes.Case:
                    const string caseSqlQuery = @"
select id, hardware_id, motherboard_format, max_power_supply_length, max_gpu_length, max_air_height, max_aio_fans_count from pc_case where hardware_id = @HardwareId
";
                    
                    var caseSqlParams = new
                    {
                        HardwareId = part.Id,
                    };
                    
                    var pcCase = (await connection.QueryAsync<PcCaseEntity>(
                            new CommandDefinition(
                                caseSqlQuery,
                                caseSqlParams,
                                cancellationToken: token)))
                        .First();
                    
                    hardware.Add(new Case(
                        price: part.Price, 
                        link: part.Link,
                        model: part.Model,
                        motherboardFormat: pcCase.MotherboardFormat,
                        maxPowerSupplyLength: pcCase.MaxPowerSupplyLength,
                        maxGpuLength: pcCase.MaxGpuLength,
                        maxAirHeight: pcCase.MaxAirHeight,
                        maxAioFansCount: pcCase.MaxAioFansCount));
                    break;
                
                case (int)HardwareTypes.Cpu:
                    const string cpuSqlQuery = @"
select id, hardware_id, manufacturer, ddr5, integrated_greaphics, tdp, socket from cpu where hardware_id = @HardwareId
";
                    
                    var cpuSqlParams = new
                    {
                        HardwareId = part.Id,
                    };
                    
                    var cpu = (await connection.QueryAsync<CpuEntity>(
                            new CommandDefinition(
                                cpuSqlQuery,
                                cpuSqlParams,
                                cancellationToken: token)))
                        .First();

                    hardware.Add(new Cpu(
                        price: part.Price,
                        link: part.Link,
                        model: part.Model,
                        manufacturer: cpu.Manufacturer,
                        ddr5: cpu.Ddr5,
                        integratedGraphics: cpu.IntegratedGraphics,
                        tdp: cpu.Tdp,
                        socket: cpu.Socket));
                    break;
                
                case (int)HardwareTypes.Gpu:
                    const string gpuSqlQuery = @"
select id, hardware_id, gpu_length, required_power_supplu_wattage from gpu where hardware_id = @HardwareId
";
                    
                    var gpuSqlParams = new
                    {
                        HardwareId = part.Id,
                    };
                    
                    var gpu = (await connection.QueryAsync<GpuEntity>(
                            new CommandDefinition(
                                gpuSqlQuery,
                                gpuSqlParams,
                                cancellationToken: token)))
                        .First();

                    hardware.Add(new Gpu(
                        price: part.Price,
                        link: part.Link,
                        model: part.Model,
                        length: gpu.Length,
                        requiredPowerSupplyWattage: gpu.RequiredPowerSupplyWattage));
                    break;
                
                case (int)HardwareTypes.Mb:
                    const string mbSqlQuery = @"
select id, hardware_id, target_cpu, format, socket, ddr5 from motherboard where hardware_id = @HardwareId
";
                    
                    var mbSqlParams = new
                    {
                        HardwareId = part.Id,
                    };
                    
                    var mb = (await connection.QueryAsync<MotherboardEntity>(
                            new CommandDefinition(
                                mbSqlQuery,
                                mbSqlParams,
                                cancellationToken: token)))
                        .First();

                    hardware.Add(new MotherBoard(
                        price: part.Price,
                        link: part.Link,
                        model: part.Model,
                        targetCpu: mb.TargetCpu,
                        format: mb.Format,
                        socket: mb.Socket,
                        ddr5: mb.Ddr5
                        ));
                    break;
                
                case (int)HardwareTypes.Psu:
                    const string psuSqlQuery = @"
select id, hardware_id, wattage, certification, is_modular, power_supply_length from power_supply where hardware_id = @HardwareId
";
                    
                    var psuSqlParams = new
                    {
                        HardwareId = part.Id,
                    };
                    
                    var psu = (await connection.QueryAsync<PowerSupplyEntity>(
                            new CommandDefinition(
                                psuSqlQuery,
                                psuSqlParams,
                                cancellationToken: token)))
                        .First();

                    hardware.Add(new PowerSupply(
                        price: part.Price,
                        link: part.Link,
                        model: part.Model,
                        wattage: psu.Wattage,
                        certification: psu.Certification,
                        isModular: psu.IsModular,
                        length: psu.Length
                        ));
                    break;
                
                case (int)HardwareTypes.Ram:
                    const string ramSqlQuery = @"
select id, hardware_id, ddr5, frequency, capacity, count from ram where hardware_id = @HardwareId
";
                    
                    var ramSqlParams = new
                    {
                        HardwareId = part.Id,
                    };
                    
                    var ram = (await connection.QueryAsync<RamEntity>(
                            new CommandDefinition(
                                ramSqlQuery,
                                ramSqlParams,
                                cancellationToken: token)))
                        .First();

                    hardware.Add(new Ram(
                        price: part.Price,
                        link: part.Link,
                        model: part.Model,
                        ddr5: ram.Ddr5,
                        frequency: ram.Frequency,
                        capacity: ram.Capacity,
                        count: ram.Count));
                    break;
                
                case (int)HardwareTypes.Ssd:
                    const string ssdSqlQuery = @"
select id, hardware_id, capacity, read_speed, write_speed from ssd where hardware_id = @HardwareId
";
                    
                    var ssdSqlParams = new
                    {
                        HardwareId = part.Id,
                    };
                    
                    var ssd = (await connection.QueryAsync<SsdEntity>(
                            new CommandDefinition(
                                ssdSqlQuery,
                                ssdSqlParams,
                                cancellationToken: token)))
                        .First();

                    hardware.Add(new Ssd(
                        price: part.Price,
                        link: part.Link,
                        model: part.Model,
                        capacity: ssd.Capacity,
                        readSpeed: ssd.ReadSpeed,
                        writeSpeed: ssd.WriteSpeed));
                    break;
            }
        }
        
        return hardware;
    }
}