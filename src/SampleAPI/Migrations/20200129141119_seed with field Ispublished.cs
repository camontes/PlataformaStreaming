using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class seedwithfieldIspublished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Courses",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 27, 21, 49, 52, 828, DateTimeKind.Local).AddTicks(531), new DateTime(2019, 11, 27, 21, 49, 52, 828, DateTimeKind.Local).AddTicks(1393) });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 27, 21, 49, 52, 831, DateTimeKind.Local).AddTicks(4204), new DateTime(2019, 11, 27, 21, 49, 52, 831, DateTimeKind.Local).AddTicks(5306) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 27, 21, 49, 52, 828, DateTimeKind.Local).AddTicks(9727), new DateTime(2019, 11, 27, 21, 49, 52, 829, DateTimeKind.Local).AddTicks(727) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 27, 21, 49, 52, 832, DateTimeKind.Local).AddTicks(4766), new DateTime(2019, 11, 27, 21, 49, 52, 832, DateTimeKind.Local).AddTicks(5518) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 27, 21, 49, 52, 831, DateTimeKind.Local).AddTicks(9402), new DateTime(2019, 11, 27, 21, 49, 52, 832, DateTimeKind.Local).AddTicks(158) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 27, 21, 49, 52, 830, DateTimeKind.Local).AddTicks(7133), new DateTime(2019, 11, 27, 21, 49, 52, 830, DateTimeKind.Local).AddTicks(8321) });

            migrationBuilder.UpdateData(
                table: "UserContents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 27, 21, 49, 52, 832, DateTimeKind.Local).AddTicks(8840));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 27, 21, 49, 52, 825, DateTimeKind.Local).AddTicks(6279), new DateTime(2019, 11, 27, 21, 49, 52, 827, DateTimeKind.Local).AddTicks(5244) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 27, 21, 49, 52, 829, DateTimeKind.Local).AddTicks(7213), new DateTime(2019, 11, 27, 21, 49, 52, 829, DateTimeKind.Local).AddTicks(9222) });
        }
    }
}
