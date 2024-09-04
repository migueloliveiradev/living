namespace Living.Infraestructure.Migrations;

[Migration(2024_08_11_11_57, "AddUserSessions")]
public class AddUserSessions : Migration
{
    public override void Up()
    {
        Create.Table("UserSessions")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("UserId").AsGuid().ForeignKey("Users", "Id")
            .WithColumn("RefreshToken").AsString(255)
                                       .Unique()
            .WithColumn("CreatedAt").AsDateTime()
            .WithColumn("LastUpdatedAt").AsDateTime();
    }

    public override void Down()
    {
        Delete.Table("UserSessions");
    }
}