using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230503, TransactionBehavior.None)]
public class CreateAioType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
            CREATE TYPE aio_type AS (
                id INTEGER,
                hardware_id INTEGER,
                fans_count INTEGER
            );
        ");
    }

    public override void Down()
    {
        Execute.Sql("DROP TYPE IF EXISTS aio_type;");
    }
}