using Microsoft.EntityFrameworkCore.Migrations;

namespace Presistence.Migrations
{
    public partial class newmigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bubbleMeetDetails_bubbleDetails_BubbleId",
                table: "bubbleMeetDetails");

            migrationBuilder.AlterColumn<int>(
                name: "BubbleId",
                table: "bubbleMeetDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_bubbleMeetDetails_bubbleDetails_BubbleId",
                table: "bubbleMeetDetails",
                column: "BubbleId",
                principalTable: "bubbleDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bubbleMeetDetails_bubbleDetails_BubbleId",
                table: "bubbleMeetDetails");

            migrationBuilder.AlterColumn<int>(
                name: "BubbleId",
                table: "bubbleMeetDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_bubbleMeetDetails_bubbleDetails_BubbleId",
                table: "bubbleMeetDetails",
                column: "BubbleId",
                principalTable: "bubbleDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
