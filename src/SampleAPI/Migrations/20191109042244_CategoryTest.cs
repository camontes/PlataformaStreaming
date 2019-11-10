using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class CategoryTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 8, 23, 22, 43, 591, DateTimeKind.Local).AddTicks(1814), new DateTime(2019, 11, 8, 23, 22, 43, 591, DateTimeKind.Local).AddTicks(2499) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 8, 23, 22, 43, 589, DateTimeKind.Local).AddTicks(1183), new DateTime(2019, 11, 8, 23, 22, 43, 590, DateTimeKind.Local).AddTicks(7600) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 8, 22, 12, 53, 406, DateTimeKind.Local).AddTicks(172), new DateTime(2019, 11, 8, 22, 12, 53, 406, DateTimeKind.Local).AddTicks(1708) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 8, 22, 12, 53, 402, DateTimeKind.Local).AddTicks(5669), new DateTime(2019, 11, 8, 22, 12, 53, 405, DateTimeKind.Local).AddTicks(782) });
        }
    }
}
