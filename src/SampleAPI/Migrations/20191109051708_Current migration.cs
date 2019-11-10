using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class Currentmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 9, 0, 17, 7, 432, DateTimeKind.Local).AddTicks(6752), new DateTime(2019, 11, 9, 0, 17, 7, 432, DateTimeKind.Local).AddTicks(8672) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 9, 0, 17, 7, 428, DateTimeKind.Local).AddTicks(5812), new DateTime(2019, 11, 9, 0, 17, 7, 430, DateTimeKind.Local).AddTicks(7862) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 9, 0, 10, 7, 696, DateTimeKind.Local).AddTicks(8513), new DateTime(2019, 11, 9, 0, 10, 7, 696, DateTimeKind.Local).AddTicks(9649) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 9, 0, 10, 7, 692, DateTimeKind.Local).AddTicks(447), new DateTime(2019, 11, 9, 0, 10, 7, 696, DateTimeKind.Local).AddTicks(1547) });
        }
    }
}
