using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230509, TransactionBehavior.None)]
public class CreatePowerSupplyType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
            CREATE TYPE power_supply_type AS (
                id INTEGER,
                hardware_id INTEGER,
                wattage INTEGER,
                certification TEXT,
                is_modular BOOLEAN,
                power_supply_length INTEGER
            );
        ");
    }

    public override void Down()
    {
        Execute.Sql("DROP TYPE IF EXISTS power_supply_type;");
    }
}