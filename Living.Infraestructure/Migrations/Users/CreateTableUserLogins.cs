using FluentMigrator;

namespace Living.Infraestructure.Migrations.Users;
public class CreateTableUserLogins : Migration
{
    public override void Up()
    {
        Create.Table("user_logins")
            .WithColumn("login_provider").AsString(128).NotNullable()
            .WithColumn("provider_key").AsString(128).NotNullable()
            .WithColumn("provider_display_name").AsString(128).Nullable()
            .WithColumn("user_id").AsGuid().NotNullable();

        Create.ForeignKey("fk_user_logins_users")
            .FromTable("user_logins").ForeignColumn("user_id")
            .ToTable("users").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("fk_user_logins_users");
        Delete.Table("user_logins");
    }
}
