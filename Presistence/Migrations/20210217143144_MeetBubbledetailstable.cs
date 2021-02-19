using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Presistence.Migrations
{
    public partial class MeetBubbledetailstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BubbleMeetDetailsId",
                table: "bubbleDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "bubbleMeetDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowChat = table.Column<bool>(type: "bit", nullable: false),
                    UserPermission = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bubbleMeetDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bubbleDetails_BubbleMeetDetailsId",
                table: "bubbleDetails",
                column: "BubbleMeetDetailsId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.DropTable(
                name: "bubbleMeetDetails");

            migrationBuilder.DropIndex(
                name: "IX_bubbleDetails_BubbleMeetDetailsId",
                table: "bubbleDetails");

            migrationBuilder.DropColumn(
                name: "BubbleMeetDetailsId",
                table: "bubbleDetails");
        }
    }
}
