using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230506, TransactionBehavior.None)]
public class CreateCpuType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
            CREATE TYPE cpu_type AS (
                id INTEGER,
                hardware_id INTEGER,
                manufacturer TEXT,
                ddr5 BOOLEAN,
                integrated_graphics BOOLEAN,
                tdp INTEGER,
                socket TEXT
            );
        ");
    }

    public override void Down()
    {
        Execute.Sql("DROP TYPE IF EXISTS cpu_type;");
    }
}