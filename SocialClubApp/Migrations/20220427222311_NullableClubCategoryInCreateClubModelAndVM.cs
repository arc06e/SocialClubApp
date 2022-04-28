using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialClubApp.Migrations
{
    public partial class NullableClubCategoryInCreateClubModelAndVM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ClubCategory",
                table: "Clubs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ClubCategory",
                table: "Clubs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
