using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230509, TransactionBehavior.None)]
public class CreatePowerSupplyType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'power_supply_type') THEN
            CREATE TYPE power_supply_type AS (
                id INTEGER,
                hardware_id INTEGER,
                wattage INTEGER,
                certification TEXT,
                is_modular BOOLEAN,
                power_supply_length INTEGER
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
        DROP TYPE IF EXISTS power_supply_type;
    END
$$;");
    }
}