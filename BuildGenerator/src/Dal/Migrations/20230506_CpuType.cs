using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230506, TransactionBehavior.None)]
public class CreateCpuType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'cpu_type') THEN
            CREATE TYPE cpu_type AS (
                id INTEGER,
                hardware_id INTEGER,
                manufacturer TEXT,
                ddr5 BOOLEAN,
                integrated_graphics BOOLEAN,
                tdp INTEGER,
                socket TEXT
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
        DROP TYPE IF EXISTS cpu_type;
    END
$$;");
    }
}