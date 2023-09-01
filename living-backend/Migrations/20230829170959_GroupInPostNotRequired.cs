using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace living_backend.Migrations;

/// <inheritdoc />
public partial class GroupInPostNotRequired : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Posts_Groups_GroupId",
            table: "Posts");

        migrationBuilder.AlterColumn<int>(
            name: "GroupId",
            table: "Posts",
            type: "integer",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "integer");

        migrationBuilder.AddForeignKey(
            name: "FK_Posts_Groups_GroupId",
            table: "Posts",
            column: "GroupId",
            principalTable: "Groups",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Posts_Groups_GroupId",
            table: "Posts");

        migrationBuilder.AlterColumn<int>(
            name: "GroupId",
            table: "Posts",
            type: "integer",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "integer",
            oldNullable: true);

        migrationBuilder.AddForeignKey(
            name: "FK_Posts_Groups_GroupId",
            table: "Posts",
            column: "GroupId",
            principalTable: "Groups",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
