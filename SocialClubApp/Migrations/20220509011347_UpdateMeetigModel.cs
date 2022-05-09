using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialClubApp.Migrations
{
    public partial class UpdateMeetigModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Meetings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Meetings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Meetings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Meetings");
        }
    }
}
