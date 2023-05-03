using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230505, TransactionBehavior.None)]
public class CreatePcCaseType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'pc_case_type') THEN
            CREATE TYPE pc_case_type AS (
                id INTEGER,
                hardware_id INTEGER,
                motherboard_format TEXT,
                max_power_supply_length INTEGER,
                max_gpu_length INTEGER,
                max_air_height INTEGER,
                max_aio_fans_count INTEGER
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
        DROP TYPE IF EXISTS pc_case_type;
    END
$$;");
    }
}