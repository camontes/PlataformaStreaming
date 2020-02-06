using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class DeletedescriptionFiedlofsubjectandcontent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 35, 38, 822, DateTimeKind.Local).AddTicks(4536), new DateTime(2020, 2, 6, 17, 35, 38, 822, DateTimeKind.Local).AddTicks(5299) });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 35, 38, 824, DateTimeKind.Local).AddTicks(8941), new DateTime(2020, 2, 6, 17, 35, 38, 824, DateTimeKind.Local).AddTicks(9650) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 35, 38, 823, DateTimeKind.Local).AddTicks(1346), new DateTime(2020, 2, 6, 17, 35, 38, 823, DateTimeKind.Local).AddTicks(2094) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 35, 38, 825, DateTimeKind.Local).AddTicks(8643), new DateTime(2020, 2, 6, 17, 35, 38, 825, DateTimeKind.Local).AddTicks(9355) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 35, 38, 825, DateTimeKind.Local).AddTicks(3402), new DateTime(2020, 2, 6, 17, 35, 38, 825, DateTimeKind.Local).AddTicks(4117) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 35, 38, 824, DateTimeKind.Local).AddTicks(3116), new DateTime(2020, 2, 6, 17, 35, 38, 824, DateTimeKind.Local).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "UserContents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 6, 17, 35, 38, 826, DateTimeKind.Local).AddTicks(2468));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 35, 38, 819, DateTimeKind.Local).AddTicks(9760), new DateTime(2020, 2, 6, 17, 35, 38, 821, DateTimeKind.Local).AddTicks(9619) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 35, 38, 823, DateTimeKind.Local).AddTicks(7675), new DateTime(2020, 2, 6, 17, 35, 38, 823, DateTimeKind.Local).AddTicks(8666) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
