using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230511, TransactionBehavior.None)]
public class CreateSsdType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'ssd_type') THEN
            CREATE TYPE ssd_type AS (
                id INTEGER,
                hardware_id INTEGER,
                capacity INTEGER, 
                read_speed INTEGER,
                write_speed INTEGER
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
        DROP TYPE IF EXISTS ssd_type;
    END
$$;");
    }
}