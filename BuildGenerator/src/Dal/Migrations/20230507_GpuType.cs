using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230507, TransactionBehavior.None)]
public class CreateGpuType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'gpu_type') THEN
            CREATE TYPE gpu_type AS (
                id INTEGER,
                hardware_id INTEGER,
                gpu_length INTEGER,
                required_power_supply_wattage INTEGER
            );
        END IF;
    END
$$;");
    }

    public override void Down()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        DROP TYPE IF EXISTS gpu_type;
    END
$$;");
    }
}