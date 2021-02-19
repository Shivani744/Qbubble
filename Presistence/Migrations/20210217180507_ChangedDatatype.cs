using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Presistence.Migrations
{
    public partial class ChangedDatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserPermission",
                table: "bubbleMeetDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "MeetTiming",
                table: "bubbleMeetDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetTiming",
                table: "bubbleMeetDetails");

            migrationBuilder.AlterColumn<bool>(
                name: "UserPermission",
                table: "bubbleMeetDetails",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
