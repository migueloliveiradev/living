using FluentMigrator;

namespace Living.Infraestructure.Migrations.Users;
public class CreateTableRoles : Migration
{
    public override void Up()
    {
        Create.Table("roles")
            .WithColumn("id").AsGuid().PrimaryKey().Identity()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("normalized_name").AsString().NotNullable()
            .WithColumn("concurrency_stamp").AsString().NotNullable();

        Create.Index("idx_roles_normalized_name")
            .OnTable("roles")
            .OnColumn("normalized_name");
    }

    public override void Down()
    {
        Delete.Table("roles");
    }
}
