using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class FixUsersCoursesRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 14, 22, 1, 15, 515, DateTimeKind.Local).AddTicks(6040), new DateTime(2019, 11, 14, 22, 1, 15, 515, DateTimeKind.Local).AddTicks(6816) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 14, 22, 1, 15, 516, DateTimeKind.Local).AddTicks(3014), new DateTime(2019, 11, 14, 22, 1, 15, 516, DateTimeKind.Local).AddTicks(3946) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 14, 22, 1, 15, 512, DateTimeKind.Local).AddTicks(7729), new DateTime(2019, 11, 14, 22, 1, 15, 515, DateTimeKind.Local).AddTicks(1277) });

            migrationBuilder.InsertData(
                table: "UsersCourses",
                columns: new[] { "Id", "CourseId", "CreatedAt", "IsEnd", "Rating", "UpdatedAt", "Username" },
                values: new object[] { 1, 1, new DateTime(2019, 11, 14, 22, 1, 15, 516, DateTimeKind.Local).AddTicks(8976), false, 0f, new DateTime(2019, 11, 14, 22, 1, 15, 517, DateTimeKind.Local).AddTicks(285), "Mr. Sample" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 14, 21, 54, 4, 242, DateTimeKind.Local).AddTicks(6098), new DateTime(2019, 11, 14, 21, 54, 4, 242, DateTimeKind.Local).AddTicks(7331) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 14, 21, 54, 4, 243, DateTimeKind.Local).AddTicks(4099), new DateTime(2019, 11, 14, 21, 54, 4, 243, DateTimeKind.Local).AddTicks(8842) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 14, 21, 54, 4, 239, DateTimeKind.Local).AddTicks(4358), new DateTime(2019, 11, 14, 21, 54, 4, 241, DateTimeKind.Local).AddTicks(6819) });
        }
    }
}
