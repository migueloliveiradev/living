using FluentMigrator;

namespace Living.Infraestructure.Migrations.Users;
public class CreateTableUserClaims : Migration
{
    public override void Up()
    {
        Create.Table("user_claims")
            .WithColumn("id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("claim_type").AsString(128).NotNullable()
            .WithColumn("claim_value").AsString(128).NotNullable()
            .WithColumn("user_id").AsGuid().NotNullable();

        Create.ForeignKey("fk_user_claims_users")
            .FromTable("user_claims").ForeignColumn("user_id")
            .ToTable("users").PrimaryColumn("id");
    }

    public override void Down()
    {
        Delete.ForeignKey("fk_user_claims_users");
        Delete.Table("user_claims");
    }
}
