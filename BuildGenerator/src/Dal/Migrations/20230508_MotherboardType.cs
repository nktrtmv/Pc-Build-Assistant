using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230508, TransactionBehavior.None)]
public class CreateMotherboardType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'motherboard_type') THEN
            CREATE TYPE motherboard_type AS (
                id INTEGER,
                hardware_id INTEGER,
                target_cpu TEXT,
                format TEXT,
                socket TEXT,
                ddr5 BOOLEAN
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
        DROP TYPE IF EXISTS motherboard_type;
    END
$$;");
    }
}