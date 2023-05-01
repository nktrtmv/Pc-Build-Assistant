using Dal.Entities;
using Dal.Settings;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Npgsql;
using Npgsql.NameTranslation;

namespace Dal.Infrastructure;

public static class Postgres
{
    private static readonly INpgsqlNameTranslator s_translator = new NpgsqlSnakeCaseNameTranslator();

    /// <summary>
    /// Map DAL models to composite types (enables UNNEST)
    /// </summary>
    public static void MapCompositeTypes()
    {
        var mapper = NpgsqlConnection.GlobalTypeMapper;
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        
        mapper.MapComposite<AioEntity>("aio_type", s_translator);
        mapper.MapComposite<AirEntity>("air_type", s_translator);
        mapper.MapComposite<CpuEntity>("cpu_type", s_translator);
        mapper.MapComposite<GpuEntity>("gpu_type", s_translator);
        mapper.MapComposite<MotherboardEntity>("motherboard_type", s_translator);
        mapper.MapComposite<PcCaseEntity>("pc_case_type", s_translator);
        mapper.MapComposite<PowerSupplyEntity>("power_supply_type", s_translator);
        mapper.MapComposite<RamEntity>("ram_type", s_translator);
        mapper.MapComposite<SsdEntity>("ssd_type", s_translator);
    }

    /// <summary>
    /// Add migration infrastructure
    /// </summary>
    public static void AddMigrations(IServiceCollection services)
    {
        services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb.AddPostgres()
                .WithGlobalConnectionString(s =>
                {
                    var cfg = s.GetRequiredService<IOptions<DalOptions>>();
                    return cfg.Value.ConnectionString;
                })
                .ScanIn(typeof(Postgres).Assembly).For.Migrations()
            )
            .AddLogging(lb => lb.AddFluentMigratorConsole());
    }
}