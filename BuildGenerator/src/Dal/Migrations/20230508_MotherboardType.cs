using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230508, TransactionBehavior.None)]
public class CreateMotherboardType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
            CREATE TYPE motherboard_type AS (
                id INTEGER,
                hardware_id INTEGER,
                target_cpu TEXT,
                format TEXT,
                socket TEXT,
                ddr5 BOOLEAN
            );
        ");
    }

    public override void Down()
    {
        Execute.Sql("DROP TYPE IF EXISTS motherboard_type;");
    }
}