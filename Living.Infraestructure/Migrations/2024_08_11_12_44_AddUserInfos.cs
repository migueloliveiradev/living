namespace Living.Infraestructure.Migrations;

[Migration(2024_08_11_12_44, "AddUserInfos")]
public class AddUserInfos : Migration
{
    public override void Up()
    {
        Alter.Table("Users")
            .AddColumn("Name").AsString(255).NotNullable()
            .AddColumn("Bio").AsString(255).Nullable()
            .AddColumn("Birthday").AsDate().NotNullable();

        Alter.Table("Users")
            .AddColumn("CreatedAt").AsDateTime().NotNullable()
            .AddColumn("LastUpdatedAt").AsDateTime().NotNullable();
    }

    public override void Down()
    {
        Delete.Column("Name").FromTable("Users");
        Delete.Column("Bio").FromTable("Users");
        Delete.Column("Birthday").FromTable("Users");

        Delete.Column("CreatedAt").FromTable("Users");
        Delete.Column("LastUpdatedAt").FromTable("Users");
    }
}