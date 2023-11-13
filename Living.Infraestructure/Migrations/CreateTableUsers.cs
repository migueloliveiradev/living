using FluentMigrator;
using Living.Infraestructure.Migrations.Extensions;

namespace Living.Infraestructure.Migrations;

[Migration(2023_11_13_10_52, "Create Table to entity Users")]
public class CreateTableUsers : Migration
{
    public override void Up()
    {
        Create.Table("users")
            .WithColumn("id").AsGuid().PrimaryKey().Identity()
            .WithColumn("name").AsString(100).NotNullable()
            .WithColumn("email").AsString(100).NotNullable()
            .WithColumn("password").AsString(100).NotNullable()
            .WithTimestamps();
    }

    public override void Down()
    {
        Delete.Table("users");
    }
}
