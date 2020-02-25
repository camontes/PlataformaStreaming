using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class CreatefieldPostedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostedAt",
                table: "Courses",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 24, 19, 17, 2, 491, DateTimeKind.Local).AddTicks(3615), new DateTime(2020, 2, 24, 19, 17, 2, 491, DateTimeKind.Local).AddTicks(4490) });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 24, 19, 17, 2, 494, DateTimeKind.Local).AddTicks(407), new DateTime(2020, 2, 24, 19, 17, 2, 494, DateTimeKind.Local).AddTicks(1810) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 24, 19, 17, 2, 492, DateTimeKind.Local).AddTicks(901), new DateTime(2020, 2, 24, 19, 17, 2, 492, DateTimeKind.Local).AddTicks(1822) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 24, 19, 17, 2, 495, DateTimeKind.Local).AddTicks(9147), new DateTime(2020, 2, 24, 19, 17, 2, 496, DateTimeKind.Local).AddTicks(215) });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Content", "CreatedAt", "IsActive", "IsCorrect", "QuestionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, "Respuesta Pregunta 2", new DateTime(2020, 2, 24, 19, 17, 2, 496, DateTimeKind.Local).AddTicks(1118), true, false, 1, new DateTime(2020, 2, 24, 19, 17, 2, 496, DateTimeKind.Local).AddTicks(1126) },
                    { 3, "Respuesta Pregunta 3", new DateTime(2020, 2, 24, 19, 17, 2, 496, DateTimeKind.Local).AddTicks(1134), true, false, 1, new DateTime(2020, 2, 24, 19, 17, 2, 496, DateTimeKind.Local).AddTicks(1136) },
                    { 4, "Respuesta Pregunta 4", new DateTime(2020, 2, 24, 19, 17, 2, 496, DateTimeKind.Local).AddTicks(1139), true, false, 1, new DateTime(2020, 2, 24, 19, 17, 2, 496, DateTimeKind.Local).AddTicks(1141) }
                });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 24, 19, 17, 2, 494, DateTimeKind.Local).AddTicks(8267), new DateTime(2020, 2, 24, 19, 17, 2, 494, DateTimeKind.Local).AddTicks(9573) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 24, 19, 17, 2, 493, DateTimeKind.Local).AddTicks(3621), new DateTime(2020, 2, 24, 19, 17, 2, 493, DateTimeKind.Local).AddTicks(4612) });

            migrationBuilder.UpdateData(
                table: "UserContents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 24, 19, 17, 2, 496, DateTimeKind.Local).AddTicks(4169));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 24, 19, 17, 2, 487, DateTimeKind.Local).AddTicks(8534), new DateTime(2020, 2, 24, 19, 17, 2, 490, DateTimeKind.Local).AddTicks(8268) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 24, 19, 17, 2, 492, DateTimeKind.Local).AddTicks(8575), new DateTime(2020, 2, 24, 19, 17, 2, 492, DateTimeKind.Local).AddTicks(9410) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "PostedAt",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 37, 55, 814, DateTimeKind.Local).AddTicks(6444), new DateTime(2020, 2, 6, 17, 37, 55, 814, DateTimeKind.Local).AddTicks(8103) });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 37, 55, 818, DateTimeKind.Local).AddTicks(1218), new DateTime(2020, 2, 6, 17, 37, 55, 818, DateTimeKind.Local).AddTicks(2765) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 37, 55, 815, DateTimeKind.Local).AddTicks(7240), new DateTime(2020, 2, 6, 17, 37, 55, 815, DateTimeKind.Local).AddTicks(8625) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 37, 55, 819, DateTimeKind.Local).AddTicks(6237), new DateTime(2020, 2, 6, 17, 37, 55, 819, DateTimeKind.Local).AddTicks(7566) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 37, 55, 818, DateTimeKind.Local).AddTicks(8564), new DateTime(2020, 2, 6, 17, 37, 55, 818, DateTimeKind.Local).AddTicks(9653) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 37, 55, 817, DateTimeKind.Local).AddTicks(3713), new DateTime(2020, 2, 6, 17, 37, 55, 817, DateTimeKind.Local).AddTicks(4828) });

            migrationBuilder.UpdateData(
                table: "UserContents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 6, 17, 37, 55, 820, DateTimeKind.Local).AddTicks(2102));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 37, 55, 811, DateTimeKind.Local).AddTicks(6305), new DateTime(2020, 2, 6, 17, 37, 55, 813, DateTimeKind.Local).AddTicks(9607) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 37, 55, 816, DateTimeKind.Local).AddTicks(7256), new DateTime(2020, 2, 6, 17, 37, 55, 816, DateTimeKind.Local).AddTicks(8551) });
        }
    }
}
