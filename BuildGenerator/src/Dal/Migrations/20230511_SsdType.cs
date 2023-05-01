using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230511, TransactionBehavior.None)]
public class CreateSsdType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
            CREATE TYPE ssd_type AS (
                id INTEGER,
                hardware_id INTEGER,
                capacity INTEGER, 
                read_speed INTEGER,
                write_speed INTEGER
            );
        ");
    }

    public override void Down()
    {
        Execute.Sql("DROP TYPE IF EXISTS ssd_type;");
    }
}