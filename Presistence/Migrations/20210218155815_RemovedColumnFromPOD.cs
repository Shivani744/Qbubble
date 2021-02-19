using Microsoft.EntityFrameworkCore.Migrations;

namespace Presistence.Migrations
{
    public partial class RemovedColumnFromPOD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BubbleName",
                table: "podDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BubbleName",
                table: "podDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
