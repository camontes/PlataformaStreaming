using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class AddUsernameatCourseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Courses",
                nullable: true);

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
                columns: new[] { "CreatedAt", "UpdatedAt", "Username" },
                values: new object[] { new DateTime(2019, 11, 27, 21, 49, 52, 828, DateTimeKind.Local).AddTicks(9727), new DateTime(2019, 11, 27, 21, 49, 52, 829, DateTimeKind.Local).AddTicks(727), "Mr. Sample" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Username",
                table: "Courses",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_Username",
                table: "Courses",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_Username",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Username",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 23, 19, 3, 28, 91, DateTimeKind.Local).AddTicks(5033), new DateTime(2019, 11, 23, 19, 3, 28, 91, DateTimeKind.Local).AddTicks(6027) });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 23, 19, 3, 28, 96, DateTimeKind.Local).AddTicks(8711), new DateTime(2019, 11, 23, 19, 3, 28, 96, DateTimeKind.Local).AddTicks(9869) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 23, 19, 3, 28, 92, DateTimeKind.Local).AddTicks(2084), new DateTime(2019, 11, 23, 19, 3, 28, 92, DateTimeKind.Local).AddTicks(3194) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 23, 19, 3, 28, 99, DateTimeKind.Local).AddTicks(2502), new DateTime(2019, 11, 23, 19, 3, 28, 101, DateTimeKind.Local).AddTicks(6376) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 23, 19, 3, 28, 97, DateTimeKind.Local).AddTicks(7414), new DateTime(2019, 11, 23, 19, 3, 28, 97, DateTimeKind.Local).AddTicks(8387) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 23, 19, 3, 28, 96, DateTimeKind.Local).AddTicks(514), new DateTime(2019, 11, 23, 19, 3, 28, 96, DateTimeKind.Local).AddTicks(1948) });

            migrationBuilder.UpdateData(
                table: "UserContents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 11, 23, 19, 3, 28, 102, DateTimeKind.Local).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 23, 19, 3, 28, 88, DateTimeKind.Local).AddTicks(1277), new DateTime(2019, 11, 23, 19, 3, 28, 90, DateTimeKind.Local).AddTicks(9111) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 23, 19, 3, 28, 94, DateTimeKind.Local).AddTicks(3049), new DateTime(2019, 11, 23, 19, 3, 28, 94, DateTimeKind.Local).AddTicks(9038) });
        }
    }
}
