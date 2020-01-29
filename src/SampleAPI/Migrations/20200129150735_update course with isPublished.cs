using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class updatecoursewithisPublished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 29, 10, 7, 34, 446, DateTimeKind.Local).AddTicks(8156), new DateTime(2020, 1, 29, 10, 7, 34, 446, DateTimeKind.Local).AddTicks(9115) });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 29, 10, 7, 34, 451, DateTimeKind.Local).AddTicks(5009), new DateTime(2020, 1, 29, 10, 7, 34, 451, DateTimeKind.Local).AddTicks(6558) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 29, 10, 7, 34, 447, DateTimeKind.Local).AddTicks(6256), new DateTime(2020, 1, 29, 10, 7, 34, 447, DateTimeKind.Local).AddTicks(7165) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 29, 10, 7, 34, 452, DateTimeKind.Local).AddTicks(7589), new DateTime(2020, 1, 29, 10, 7, 34, 452, DateTimeKind.Local).AddTicks(8468) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 29, 10, 7, 34, 452, DateTimeKind.Local).AddTicks(1351), new DateTime(2020, 1, 29, 10, 7, 34, 452, DateTimeKind.Local).AddTicks(2205) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 29, 10, 7, 34, 450, DateTimeKind.Local).AddTicks(5467), new DateTime(2020, 1, 29, 10, 7, 34, 450, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "UserContents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 29, 10, 7, 34, 453, DateTimeKind.Local).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 29, 10, 7, 34, 443, DateTimeKind.Local).AddTicks(8094), new DateTime(2020, 1, 29, 10, 7, 34, 446, DateTimeKind.Local).AddTicks(2458) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 29, 10, 7, 34, 449, DateTimeKind.Local).AddTicks(6583), new DateTime(2020, 1, 29, 10, 7, 34, 449, DateTimeKind.Local).AddTicks(8057) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 29, 9, 11, 18, 436, DateTimeKind.Local).AddTicks(2866), new DateTime(2020, 1, 29, 9, 11, 18, 436, DateTimeKind.Local).AddTicks(3696) });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 29, 9, 11, 18, 438, DateTimeKind.Local).AddTicks(8166), new DateTime(2020, 1, 29, 9, 11, 18, 438, DateTimeKind.Local).AddTicks(8898) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 29, 9, 11, 18, 436, DateTimeKind.Local).AddTicks(9676), new DateTime(2020, 1, 29, 9, 11, 18, 437, DateTimeKind.Local).AddTicks(755) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 29, 9, 11, 18, 439, DateTimeKind.Local).AddTicks(8701), new DateTime(2020, 1, 29, 9, 11, 18, 439, DateTimeKind.Local).AddTicks(9886) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 29, 9, 11, 18, 439, DateTimeKind.Local).AddTicks(2757), new DateTime(2020, 1, 29, 9, 11, 18, 439, DateTimeKind.Local).AddTicks(3477) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 29, 9, 11, 18, 438, DateTimeKind.Local).AddTicks(2218), new DateTime(2020, 1, 29, 9, 11, 18, 438, DateTimeKind.Local).AddTicks(3036) });

            migrationBuilder.UpdateData(
                table: "UserContents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 29, 9, 11, 18, 440, DateTimeKind.Local).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 29, 9, 11, 18, 433, DateTimeKind.Local).AddTicks(8326), new DateTime(2020, 1, 29, 9, 11, 18, 435, DateTimeKind.Local).AddTicks(8381) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 1, 29, 9, 11, 18, 437, DateTimeKind.Local).AddTicks(6954), new DateTime(2020, 1, 29, 9, 11, 18, 437, DateTimeKind.Local).AddTicks(7694) });
        }
    }
}
