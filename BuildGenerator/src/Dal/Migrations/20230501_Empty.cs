using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230501, TransactionBehavior.None)]
public class Empty : Migration
{
    public override void Up()
    {
    }

    public override void Down()
    {
    }
}