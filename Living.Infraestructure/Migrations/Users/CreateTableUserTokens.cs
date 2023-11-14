using FluentMigrator;

namespace Living.Infraestructure.Migrations.Users;
public class CreateTableUserTokens : Migration
{
    public override void Up()
    {
        Create.Table("user_tokens")
            .WithColumn("user_id").AsGuid().PrimaryKey()
            .WithColumn("login_provider").AsString(255).NotNullable()
            .WithColumn("name").AsString(255).NotNullable()
            .WithColumn("value").AsString(255).NotNullable();

        Create.ForeignKey("fk_user_tokens_users")
            .FromTable("user_tokens").ForeignColumn("user_id")
            .ToTable("users").PrimaryColumn("id");
    }

    public override void Down()
    {
        Delete.Table("user_tokens");
    }
}
