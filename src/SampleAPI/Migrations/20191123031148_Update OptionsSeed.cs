using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class UpdateOptionsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 22, 22, 11, 47, 169, DateTimeKind.Local).AddTicks(8151), new DateTime(2019, 11, 22, 22, 11, 47, 170, DateTimeKind.Local).AddTicks(6029) });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 22, 22, 11, 47, 175, DateTimeKind.Local).AddTicks(4993), new DateTime(2019, 11, 22, 22, 11, 47, 175, DateTimeKind.Local).AddTicks(6106) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 22, 22, 11, 47, 173, DateTimeKind.Local).AddTicks(279), new DateTime(2019, 11, 22, 22, 11, 47, 173, DateTimeKind.Local).AddTicks(1550) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "CreatedAt", "UpdatedAt" },
                values: new object[] { "Respuesta Pregunta 1", new DateTime(2019, 11, 22, 22, 11, 47, 177, DateTimeKind.Local).AddTicks(1333), new DateTime(2019, 11, 22, 22, 11, 47, 177, DateTimeKind.Local).AddTicks(5009) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 22, 22, 11, 47, 176, DateTimeKind.Local).AddTicks(1832), new DateTime(2019, 11, 22, 22, 11, 47, 176, DateTimeKind.Local).AddTicks(2882) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 22, 22, 11, 47, 174, DateTimeKind.Local).AddTicks(5634), new DateTime(2019, 11, 22, 22, 11, 47, 174, DateTimeKind.Local).AddTicks(6746) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 22, 22, 11, 47, 164, DateTimeKind.Local).AddTicks(1845), new DateTime(2019, 11, 22, 22, 11, 47, 166, DateTimeKind.Local).AddTicks(3952) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 22, 22, 11, 47, 173, DateTimeKind.Local).AddTicks(7472), new DateTime(2019, 11, 22, 22, 11, 47, 173, DateTimeKind.Local).AddTicks(8405) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 22, 20, 4, 43, 187, DateTimeKind.Local).AddTicks(3200), new DateTime(2019, 11, 22, 20, 4, 43, 187, DateTimeKind.Local).AddTicks(4514) });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 22, 20, 4, 43, 194, DateTimeKind.Local).AddTicks(3893), new DateTime(2019, 11, 22, 20, 4, 43, 194, DateTimeKind.Local).AddTicks(5568) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 22, 20, 4, 43, 188, DateTimeKind.Local).AddTicks(8731), new DateTime(2019, 11, 22, 20, 4, 43, 189, DateTimeKind.Local).AddTicks(974) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "CreatedAt", "UpdatedAt" },
                values: new object[] { "Pregunta Curso 1", new DateTime(2019, 11, 22, 20, 4, 43, 199, DateTimeKind.Local).AddTicks(2467), new DateTime(2019, 11, 22, 20, 4, 43, 200, DateTimeKind.Local).AddTicks(274) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 22, 20, 4, 43, 196, DateTimeKind.Local).AddTicks(981), new DateTime(2019, 11, 22, 20, 4, 43, 196, DateTimeKind.Local).AddTicks(3359) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 22, 20, 4, 43, 191, DateTimeKind.Local).AddTicks(3172), new DateTime(2019, 11, 22, 20, 4, 43, 191, DateTimeKind.Local).AddTicks(4672) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 22, 20, 4, 43, 181, DateTimeKind.Local).AddTicks(7746), new DateTime(2019, 11, 22, 20, 4, 43, 186, DateTimeKind.Local).AddTicks(5418) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 22, 20, 4, 43, 190, DateTimeKind.Local).AddTicks(1), new DateTime(2019, 11, 22, 20, 4, 43, 190, DateTimeKind.Local).AddTicks(1417) });
        }
    }
}
