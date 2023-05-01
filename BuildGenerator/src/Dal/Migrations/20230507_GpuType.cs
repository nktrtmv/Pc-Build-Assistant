using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230507, TransactionBehavior.None)]
public class CreateGpuType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
            CREATE TYPE gpu_type AS (
                id INTEGER,
                hardware_id INTEGER,
                gpu_length INTEGER,
                required_power_supply_wattage INTEGER
            );
        ");
    }

    public override void Down()
    {
        Execute.Sql("DROP TYPE IF EXISTS gpu_type;");
    }
}