using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialClubApp.Migrations
{
    public partial class AddedCloudinaryForImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Clubs");
        }
    }
}
