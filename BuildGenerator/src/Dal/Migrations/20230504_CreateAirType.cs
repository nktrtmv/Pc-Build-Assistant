using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230504, TransactionBehavior.None)]
public class CreateAirType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
            CREATE TYPE air_type AS (
                id INTEGER,
                hardware_id INTEGER,
                tdp INTEGER,
                height INTEGER
            );
        ");
    }

    public override void Down()
    {
        Execute.Sql("DROP TYPE IF EXISTS air_type;");
    }
}