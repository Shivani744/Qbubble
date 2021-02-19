using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Presistence.Migrations
{
    public partial class addedNewColumnInPod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "podDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PODName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCreateMeet = table.Column<bool>(type: "bit", nullable: false),
                    IsAllowtoEdit = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DistributionCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BubbleAdded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BubbleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BubbleId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_podDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_podDetails_bubbleDetails_BubbleId",
                        column: x => x.BubbleId,
                        principalTable: "bubbleDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_podDetails_BubbleId",
                table: "podDetails",
                column: "BubbleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "podDetails");

        }
    }
}
