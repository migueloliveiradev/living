namespace Living.Infraestructure.Migrations;

[Migration(2024_07_27_15_05, "AddIdentity")]
public class AddIdentity : Migration
{
    public override void Up()
    {
        Create.Table("Users")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("UserName").AsString(20)
                                   .Unique()
            .WithColumn("Email").AsString(256)
                                .Unique()
            .WithColumn("EmailConfirmed").AsBoolean()
            .WithColumn("PasswordHash").AsString().Nullable()
            .WithColumn("SecurityStamp").AsString().Nullable()
            .WithColumn("PhoneNumber").AsString().Nullable()
            .WithColumn("PhoneNumberConfirmed").AsBoolean()
            .WithColumn("TwoFactorEnabled").AsBoolean()
            .WithColumn("LockoutEnd").AsDateTime().Nullable()
            .WithColumn("LockoutEnabled").AsBoolean()
            .WithColumn("AccessFailedCount").AsInt32();

        Create.Table("Roles")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("Name").AsString(256).Unique();

        Create.Table("RoleClaims")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("ClaimType").AsString()
            .WithColumn("ClaimValue").AsString()
            .WithColumn("RoleId").AsGuid()
                               .Indexed()
                               .ForeignKey("Roles", "Id");

        Create.Table("UserRoles")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("UserId").AsGuid()
                               .Indexed()
                               .ForeignKey("Users", "Id")
            .WithColumn("RoleId").AsGuid()
                               .Indexed()
                               .ForeignKey("Roles", "Id");

        Create.Table("UserClaims")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("ClaimType").AsString()
            .WithColumn("ClaimValue").AsString()
            .WithColumn("UserId").AsGuid()
                               .Indexed()
                               .ForeignKey("Users", "Id");

        Create.Table("UserLogins")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("LoginProvider").AsString().PrimaryKey()
            .WithColumn("ProviderKey").AsString().PrimaryKey()
            .WithColumn("ProviderDisplayName").AsString().Nullable()
            .WithColumn("UserId").AsGuid()
                               .Indexed()
                               .ForeignKey("Users", "Id");

        Create.Table("UserTokens")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("UserId").AsGuid()
                               .Indexed()
                               .ForeignKey("Users", "Id")
            .WithColumn("LoginProvider").AsString()
            .WithColumn("Name").AsString()
            .WithColumn("Value").AsString().Nullable();
    }

    public override void Down()
    {
        Delete.Table("UserTokens");
        Delete.Table("UserLogins");
        Delete.Table("UserClaims");
        Delete.Table("UserRoles");
        Delete.Table("Users");
        Delete.Table("RoleClaims");
        Delete.Table("Roles");
    }
}
