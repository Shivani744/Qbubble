using Microsoft.EntityFrameworkCore.Migrations;

namespace Presistence.Migrations
{
    public partial class addedforeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BubbleId",
                table: "bubbleMeetDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bubbleMeetDetails_BubbleId",
                table: "bubbleMeetDetails",
                column: "BubbleId");

            migrationBuilder.AddForeignKey(
                name: "FK_bubbleMeetDetails_bubbleDetails_BubbleId",
                table: "bubbleMeetDetails",
                column: "BubbleId",
                principalTable: "bubbleDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bubbleMeetDetails_bubbleDetails_BubbleId",
                table: "bubbleMeetDetails");

            migrationBuilder.DropIndex(
                name: "IX_bubbleMeetDetails_BubbleId",
                table: "bubbleMeetDetails");

            migrationBuilder.DropColumn(
                name: "BubbleId",
                table: "bubbleMeetDetails");
        }
    }
}
