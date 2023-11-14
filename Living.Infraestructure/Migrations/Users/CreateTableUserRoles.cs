using FluentMigrator;

namespace Living.Infraestructure.Migrations.Users;
public class CreateTableUserRoles : Migration
{
    public override void Up()
    {
        Create.Table("user_roles")
            .WithColumn("user_id").AsGuid().PrimaryKey()
            .WithColumn("role_id").AsGuid().PrimaryKey();

        Create.ForeignKey("fk_user_roles_user_id")
            .FromTable("user_roles").ForeignColumn("user_id")
            .ToTable("users").PrimaryColumn("id");

        Create.ForeignKey("fk_user_roles_role_id")
            .FromTable("user_roles").ForeignColumn("role_id")
            .ToTable("roles").PrimaryColumn("id");
    }

    public override void Down()
    {
        Delete.Table("user_roles");
    }
}
