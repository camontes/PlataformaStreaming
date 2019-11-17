using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class AddSeedExtensionstoSubjectandContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 17, 17, 48, 31, 73, DateTimeKind.Local).AddTicks(7841), new DateTime(2019, 11, 17, 17, 48, 31, 73, DateTimeKind.Local).AddTicks(9168) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 17, 17, 48, 31, 74, DateTimeKind.Local).AddTicks(8891), new DateTime(2019, 11, 17, 17, 48, 31, 75, DateTimeKind.Local).AddTicks(4660) });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CourseId", "CreatedAt", "Description", "IsActive", "Name", "UpdatedAt" },
                values: new object[] { 1, 1, new DateTime(2019, 11, 17, 17, 48, 31, 77, DateTimeKind.Local).AddTicks(8614), "Descripcion Tema1 Blender", true, "Tema1 Blender", new DateTime(2019, 11, 17, 17, 48, 31, 78, DateTimeKind.Local).AddTicks(535) });

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 17, 17, 48, 31, 76, DateTimeKind.Local).AddTicks(5500), new DateTime(2019, 11, 17, 17, 48, 31, 76, DateTimeKind.Local).AddTicks(8418) });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "Name", "SubjectId", "UpdatedAt", "Url" },
                values: new object[] { 1, new DateTime(2019, 11, 17, 17, 48, 31, 84, DateTimeKind.Local).AddTicks(2207), "Descripcion Contenido Tema1", true, "Contenido Tema1", 1, new DateTime(2019, 11, 17, 17, 48, 31, 84, DateTimeKind.Local).AddTicks(3889), "www.google.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 17, 16, 40, 41, 900, DateTimeKind.Local).AddTicks(2059), new DateTime(2019, 11, 17, 16, 40, 41, 900, DateTimeKind.Local).AddTicks(3065) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 17, 16, 40, 41, 901, DateTimeKind.Local).AddTicks(33), new DateTime(2019, 11, 17, 16, 40, 41, 901, DateTimeKind.Local).AddTicks(1326) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 17, 16, 40, 41, 896, DateTimeKind.Local).AddTicks(2012), new DateTime(2019, 11, 17, 16, 40, 41, 899, DateTimeKind.Local).AddTicks(4737) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 17, 16, 40, 41, 901, DateTimeKind.Local).AddTicks(8440), new DateTime(2019, 11, 17, 16, 40, 41, 901, DateTimeKind.Local).AddTicks(9511) });
        }
    }
}
