using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230504, TransactionBehavior.None)]
public class CreateAirType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'air_type') THEN
            CREATE TYPE air_type AS (
                id INTEGER,
                hardware_id INTEGER,
                tdp INTEGER,
                height INTEGER
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
        DROP TYPE IF EXISTS air_type;
    END
$$;");
    }
}