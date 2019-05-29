using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class FixDescriptionColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descrition",
                schema: "api",
                table: "Book",
                newName: "Description");

            migrationBuilder.UpdateData(
                schema: "api",
                table: "Author",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthday", "DateOfDeath" },
                values: new object[] { new DateTime(1969, 6, 8, 20, 33, 41, 789, DateTimeKind.Local).AddTicks(4492), new DateTime(2018, 5, 28, 20, 33, 41, 790, DateTimeKind.Local).AddTicks(6867) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "api",
                table: "Book",
                newName: "Descrition");

            migrationBuilder.UpdateData(
                schema: "api",
                table: "Author",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthday", "DateOfDeath" },
                values: new object[] { new DateTime(1969, 5, 31, 9, 11, 54, 801, DateTimeKind.Local).AddTicks(6989), new DateTime(2018, 5, 20, 9, 11, 54, 802, DateTimeKind.Local).AddTicks(9757) });
        }
    }
}
