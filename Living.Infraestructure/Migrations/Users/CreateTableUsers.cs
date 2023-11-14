using FluentMigrator;
using Living.Infraestructure.Migrations.Extensions;

namespace Living.Infraestructure.Migrations.Users;

[Migration(2023_11_13_10_52, "Create Table to entity Users")]
public class CreateTableUsers : Migration
{
    public override void Up()
    {
        Create.Table("users")
            .WithId()
            .WithColumn("name").AsString(100).NotNullable()
            .WithColumn("username").AsString(100).NotNullable().Unique()
            .WithColumn("normalized_username").AsString(100).NotNullable().Unique()
            .WithColumn("email").AsString(100).NotNullable()
            .WithColumn("photo_file_name").AsString(100).Nullable()
            .WithColumn("banner_file_name").AsString(100).Nullable()
            .WithColumn("bio").AsString(250).Nullable()
            .WithColumn("birthday").AsDate().NotNullable()
            .WithColumn("normalized_email").AsString(100).NotNullable()
            .WithColumn("email_confirmed").AsBoolean().NotNullable()
            .WithColumn("password_hash").AsString(100).NotNullable()
            .WithColumn("security_stamp").AsString(100).NotNullable()
            .WithColumn("concurrency_stamp").AsString(100).NotNullable()
            .WithColumn("phone_number").AsString(100).Nullable()
            .WithColumn("phone_number_confirmed").AsBoolean().NotNullable()
            .WithColumn("two_factor_enabled").AsBoolean().NotNullable()
            .WithColumn("lockout_end").AsDateTimeOffset().Nullable()
            .WithColumn("lockout_enabled").AsBoolean().NotNullable()
            .WithColumn("access_failed_count").AsInt32().NotNullable()
            .WithTimestamps();
    }

    public override void Down()
    {
        Delete.Table("users");
    }
}
