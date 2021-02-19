using Microsoft.EntityFrameworkCore.Migrations;

namespace Presistence.Migrations
{
    public partial class longilati : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "userDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitute",
                table: "userDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "userDetails");

            migrationBuilder.DropColumn(
                name: "Longitute",
                table: "userDetails");
        }
    }
}
