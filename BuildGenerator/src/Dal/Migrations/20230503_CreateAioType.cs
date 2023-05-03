using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230503, TransactionBehavior.None)]
public class CreateAioType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'aio_type') THEN
            CREATE TYPE aio_type AS (
                id INTEGER,
                hardware_id INTEGER,
                fans_count INTEGER
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
        DROP TYPE IF EXISTS aio_type;
    END
$$;");
    }
}