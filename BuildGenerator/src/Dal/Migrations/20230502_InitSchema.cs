using FluentMigrator;

namespace Dal.Migrations;

[Migration(20230502, TransactionBehavior.None)]
public class InitSchema : Migration 
{
    public override void Up()
    {
        Create.Table("hardware")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("product_type").AsInt32().NotNullable()
            .WithColumn("model").AsString().NotNullable()
            .WithColumn("price").AsDouble().NotNullable()
            .WithColumn("link").AsString().NotNullable();
        
        Create.Table("aio")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("hardware_id").AsInt32().NotNullable()
            .WithColumn("fans_count").AsInt32().NotNullable();

        Create.Table("air")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("hardware_id").AsInt32().NotNullable()
            .WithColumn("tdp").AsInt32().NotNullable()
            .WithColumn("height").AsInt32().NotNullable();

        Create.Table("pc_case")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("hardware_id").AsInt32().NotNullable()
            .WithColumn("motherboard_format").AsString().NotNullable()
            .WithColumn("max_power_supply_length").AsInt32().NotNullable()
            .WithColumn("max_gpu_length").AsInt32().NotNullable()
            .WithColumn("max_air_height").AsInt32().NotNullable()
            .WithColumn("max_aio_fans_count").AsInt32().NotNullable();

        Create.Table("cpu")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("hardware_id").AsInt32().NotNullable()
            .WithColumn("manufacturer").AsString().NotNullable()
            .WithColumn("ddr5").AsBoolean().NotNullable()
            .WithColumn("integrated_graphics").AsBoolean().NotNullable()
            .WithColumn("tdp").AsInt32().NotNullable()
            .WithColumn("socket").AsString().NotNullable();

        Create.Table("gpu")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("hardware_id").AsInt32().NotNullable()
            .WithColumn("gpu_length").AsInt32().NotNullable()
            .WithColumn("required_power_supply_wattage").AsInt32().NotNullable();

        Create.Table("motherboard")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("hardware_id").AsInt32().NotNullable()
            .WithColumn("target_cpu").AsString().NotNullable()
            .WithColumn("format").AsString().NotNullable()
            .WithColumn("socket").AsString().NotNullable()
            .WithColumn("ddr5").AsBoolean().NotNullable();

        Create.Table("power_supply")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("hardware_id").AsInt32().NotNullable()
            .WithColumn("wattage").AsInt32().NotNullable()
            .WithColumn("certification").AsString().NotNullable()
            .WithColumn("is_modular").AsBoolean().NotNullable()
            .WithColumn("power_supply_length").AsInt32().NotNullable();
        
        Create.Table("ram")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("hardware_id").AsInt32().NotNullable()
            .WithColumn("ddr5").AsBoolean().NotNullable()
            .WithColumn("frequency").AsInt32().NotNullable()
            .WithColumn("capacity").AsInt32().NotNullable()
            .WithColumn("count").AsInt32().NotNullable();

        Create.Table("ssd")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("hardware_id").AsInt32().NotNullable()
            .WithColumn("capacity").AsInt32().NotNullable()
            .WithColumn("read_speed").AsInt32().NotNullable()
            .WithColumn("write_speed").AsInt32().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("hardware");
        Delete.Table("aio");
        Delete.Table("air");
        Delete.Table("pc_case");
        Delete.Table("cpu");
        Delete.Table("gpu");
        Delete.Table("motherboard");
        Delete.Table("power_supply");
        Delete.Table("ram");
        Delete.Table("ssd");
    }
}