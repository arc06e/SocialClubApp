using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialClubApp.Migrations
{
    public partial class AddCityAndStateToClub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Clubs");
        }
    }
}
