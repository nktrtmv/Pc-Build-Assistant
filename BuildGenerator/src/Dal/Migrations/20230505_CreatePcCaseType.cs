using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230505, TransactionBehavior.None)]
public class CreatePcCaseType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
            CREATE TYPE pc_case_type AS (
                id INTEGER,
                hardware_id INTEGER,
                motherboard_format TEXT,
                max_power_supply_length INTEGER,
                max_gpu_length INTEGER,
                max_air_height INTEGER,
                max_aio_fans_count INTEGER
            );
        ");
    }

    public override void Down()
    {
        Execute.Sql("DROP TYPE IF EXISTS pc_case_type;");
    }
}