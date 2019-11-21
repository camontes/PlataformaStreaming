using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class AddRatingatCourseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "UsersCourses",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Courses",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 20, 20, 18, 44, 778, DateTimeKind.Local).AddTicks(3770), new DateTime(2019, 11, 20, 20, 18, 44, 778, DateTimeKind.Local).AddTicks(4607) });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 20, 20, 18, 44, 781, DateTimeKind.Local).AddTicks(1827), new DateTime(2019, 11, 20, 20, 18, 44, 781, DateTimeKind.Local).AddTicks(2645) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 20, 20, 18, 44, 779, DateTimeKind.Local).AddTicks(1543), new DateTime(2019, 11, 20, 20, 18, 44, 779, DateTimeKind.Local).AddTicks(3991) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 20, 20, 18, 44, 780, DateTimeKind.Local).AddTicks(4833), new DateTime(2019, 11, 20, 20, 18, 44, 780, DateTimeKind.Local).AddTicks(5941) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 20, 20, 18, 44, 776, DateTimeKind.Local).AddTicks(1219), new DateTime(2019, 11, 20, 20, 18, 44, 777, DateTimeKind.Local).AddTicks(8887) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Rating", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 20, 20, 18, 44, 779, DateTimeKind.Local).AddTicks(9280), 0, new DateTime(2019, 11, 20, 20, 18, 44, 780, DateTimeKind.Local).AddTicks(79) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Courses");

            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "UsersCourses",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 17, 17, 48, 31, 73, DateTimeKind.Local).AddTicks(7841), new DateTime(2019, 11, 17, 17, 48, 31, 73, DateTimeKind.Local).AddTicks(9168) });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 17, 17, 48, 31, 84, DateTimeKind.Local).AddTicks(2207), new DateTime(2019, 11, 17, 17, 48, 31, 84, DateTimeKind.Local).AddTicks(3889) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 17, 17, 48, 31, 74, DateTimeKind.Local).AddTicks(8891), new DateTime(2019, 11, 17, 17, 48, 31, 75, DateTimeKind.Local).AddTicks(4660) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 17, 17, 48, 31, 77, DateTimeKind.Local).AddTicks(8614), new DateTime(2019, 11, 17, 17, 48, 31, 78, DateTimeKind.Local).AddTicks(535) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 17, 17, 48, 31, 70, DateTimeKind.Local).AddTicks(2227), new DateTime(2019, 11, 17, 17, 48, 31, 72, DateTimeKind.Local).AddTicks(8708) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Rating", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 17, 17, 48, 31, 76, DateTimeKind.Local).AddTicks(5500), 0f, new DateTime(2019, 11, 17, 17, 48, 31, 76, DateTimeKind.Local).AddTicks(8418) });
        }
    }
}
