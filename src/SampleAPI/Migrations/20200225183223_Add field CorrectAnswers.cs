using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class AddfieldCorrectAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CorrectAnswers",
                table: "UsersCourses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 25, 13, 32, 22, 133, DateTimeKind.Local).AddTicks(5868), new DateTime(2020, 2, 25, 13, 32, 22, 133, DateTimeKind.Local).AddTicks(6731) });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 25, 13, 32, 22, 140, DateTimeKind.Local).AddTicks(7812), new DateTime(2020, 2, 25, 13, 32, 22, 140, DateTimeKind.Local).AddTicks(9142) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 25, 13, 32, 22, 134, DateTimeKind.Local).AddTicks(8463), new DateTime(2020, 2, 25, 13, 32, 22, 134, DateTimeKind.Local).AddTicks(9503) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 25, 13, 32, 22, 142, DateTimeKind.Local).AddTicks(5781), new DateTime(2020, 2, 25, 13, 32, 22, 142, DateTimeKind.Local).AddTicks(6934) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 25, 13, 32, 22, 142, DateTimeKind.Local).AddTicks(7855), new DateTime(2020, 2, 25, 13, 32, 22, 142, DateTimeKind.Local).AddTicks(7864) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 25, 13, 32, 22, 142, DateTimeKind.Local).AddTicks(7878), new DateTime(2020, 2, 25, 13, 32, 22, 142, DateTimeKind.Local).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 25, 13, 32, 22, 142, DateTimeKind.Local).AddTicks(7882), new DateTime(2020, 2, 25, 13, 32, 22, 142, DateTimeKind.Local).AddTicks(7884) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 25, 13, 32, 22, 141, DateTimeKind.Local).AddTicks(5054), new DateTime(2020, 2, 25, 13, 32, 22, 141, DateTimeKind.Local).AddTicks(6502) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 25, 13, 32, 22, 139, DateTimeKind.Local).AddTicks(9159), new DateTime(2020, 2, 25, 13, 32, 22, 140, DateTimeKind.Local).AddTicks(904) });

            migrationBuilder.UpdateData(
                table: "UserContents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 25, 13, 32, 22, 143, DateTimeKind.Local).AddTicks(845));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 25, 13, 32, 22, 127, DateTimeKind.Local).AddTicks(6220), new DateTime(2020, 2, 25, 13, 32, 22, 133, DateTimeKind.Local).AddTicks(892) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 25, 13, 32, 22, 138, DateTimeKind.Local).AddTicks(8894), new DateTime(2020, 2, 25, 13, 32, 22, 139, DateTimeKind.Local).AddTicks(2787) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectAnswers",
                table: "UsersCourses");

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

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 24, 19, 17, 2, 496, DateTimeKind.Local).AddTicks(1118), new DateTime(2020, 2, 24, 19, 17, 2, 496, DateTimeKind.Local).AddTicks(1126) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 24, 19, 17, 2, 496, DateTimeKind.Local).AddTicks(1134), new DateTime(2020, 2, 24, 19, 17, 2, 496, DateTimeKind.Local).AddTicks(1136) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 24, 19, 17, 2, 496, DateTimeKind.Local).AddTicks(1139), new DateTime(2020, 2, 24, 19, 17, 2, 496, DateTimeKind.Local).AddTicks(1141) });

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
    }
}
