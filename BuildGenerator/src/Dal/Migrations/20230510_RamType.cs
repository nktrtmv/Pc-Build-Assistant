using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230510, TransactionBehavior.None)]
public class CreateRamType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'ram_type') THEN
            CREATE TYPE ram_type AS (
                id INTEGER,
                hardware_id INTEGER,
                ddr5 BOOLEAN,
                frequency INTEGER,
                capacity INTEGER,
                count INTEGER
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
        DROP TYPE IF EXISTS ram_type;
    END
$$;");
    }
}