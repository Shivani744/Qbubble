using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Presistence.Migrations
{
    public partial class bubbletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "userDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "userDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "otpHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "otpHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "otpHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "otpHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "bubbleDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BubbleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BubbleSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BubbleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BubbleZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BubbleType = table.Column<int>(type: "int", nullable: false),
                    BubbleValidity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOtherCountyMemberAllowed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bubbleDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bubbleDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "otpHistory");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "otpHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "otpHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "otpHistory");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "userDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "userDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
