using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230512, TransactionBehavior.None)]
public class CreateHardwareType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'hardware_type') THEN
            CREATE TYPE hardware_type AS (
                id INTEGER,
                product_type INTEGER,
                model TEXT,
                price DOUBLE PRECISION,
                link TEXT
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
        DROP TYPE IF EXISTS hardware_type;
    END
$$;");
    }
}