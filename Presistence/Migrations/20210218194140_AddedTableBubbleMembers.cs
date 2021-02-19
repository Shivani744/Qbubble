using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Presistence.Migrations
{
    public partial class AddedTableBubbleMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bubbleMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BubbleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bubbleMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bubbleMembers_bubbleDetails_BubbleId",
                        column: x => x.BubbleId,
                        principalTable: "bubbleDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bubbleMembers_userDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "userDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bubbleMembers_BubbleId",
                table: "bubbleMembers",
                column: "BubbleId");

            migrationBuilder.CreateIndex(
                name: "IX_bubbleMembers_UserId",
                table: "bubbleMembers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bubbleMembers");
        }
    }
}
