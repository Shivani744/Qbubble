using Microsoft.EntityFrameworkCore.Migrations;

namespace Presistence.Migrations
{
    public partial class addcolumnimg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicUrl",
                table: "userDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicUrl",
                table: "userDetails");
        }
    }
}
