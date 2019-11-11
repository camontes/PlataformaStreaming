using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class UpdateCreateDeleteCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CourseId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Courses",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CourseId",
                table: "Courses",
                newName: "IX_Courses_CategoryId");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 10, 18, 43, 10, 387, DateTimeKind.Local).AddTicks(1967), new DateTime(2019, 11, 10, 18, 43, 10, 387, DateTimeKind.Local).AddTicks(2949) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 10, 18, 43, 10, 388, DateTimeKind.Local).AddTicks(1639), new DateTime(2019, 11, 10, 18, 43, 10, 388, DateTimeKind.Local).AddTicks(7479) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 10, 18, 43, 10, 383, DateTimeKind.Local).AddTicks(4175), new DateTime(2019, 11, 10, 18, 43, 10, 386, DateTimeKind.Local).AddTicks(5350) });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Courses",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                newName: "IX_Courses_CourseId");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 10, 18, 17, 59, 988, DateTimeKind.Local).AddTicks(9439), new DateTime(2019, 11, 10, 18, 17, 59, 989, DateTimeKind.Local).AddTicks(668) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 10, 18, 17, 59, 989, DateTimeKind.Local).AddTicks(6938), new DateTime(2019, 11, 10, 18, 17, 59, 989, DateTimeKind.Local).AddTicks(8022) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 10, 18, 17, 59, 985, DateTimeKind.Local).AddTicks(3338), new DateTime(2019, 11, 10, 18, 17, 59, 988, DateTimeKind.Local).AddTicks(2693) });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CourseId",
                table: "Courses",
                column: "CourseId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
