using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230510, TransactionBehavior.None)]
public class CreateRamType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
            CREATE TYPE ram_type AS (
                id INTEGER,
                hardware_id INTEGER,
                ddr5 BOOLEAN,
                frequency INTEGER,
                capacity INTEGER,
                count INTEGER
            );
        ");
    }

    public override void Down()
    {
        Execute.Sql("DROP TYPE IF EXISTS ram_type;");
    }
}