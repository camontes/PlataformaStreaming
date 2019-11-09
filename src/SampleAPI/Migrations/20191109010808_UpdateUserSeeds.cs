using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class UpdateUserSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "LastName", "Name", "Photo", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 8, 20, 8, 7, 627, DateTimeKind.Local).AddTicks(4303), "Sample", "Mr.", "photo.png", new DateTime(2019, 11, 8, 20, 8, 7, 629, DateTimeKind.Local).AddTicks(653) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "LastName", "Name", "Photo", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 8, 19, 52, 34, 618, DateTimeKind.Local).AddTicks(7223), null, null, null, new DateTime(2019, 11, 8, 19, 52, 34, 636, DateTimeKind.Local).AddTicks(6963) });
        }
    }
}
