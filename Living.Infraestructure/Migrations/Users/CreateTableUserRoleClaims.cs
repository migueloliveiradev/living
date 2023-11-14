using FluentMigrator;

namespace Living.Infraestructure.Migrations.Users;
public class CreateTableUserRoleClaims : Migration
{
    public override void Up()
    {
        Create.Table("user_role_claims")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("role_id").AsGuid().NotNullable()
            .WithColumn("claim_type").AsString(100).NotNullable()
            .WithColumn("claim_value").AsString(100).NotNullable();

        Create.ForeignKey("fk_user_role_claims_role")
            .FromTable("user_role_claims").ForeignColumn("role_id")
            .ToTable("user_roles").PrimaryColumn("id");
    }

    public override void Down()
    {
        Delete.Table("UserRoleClaims");
    }
}
