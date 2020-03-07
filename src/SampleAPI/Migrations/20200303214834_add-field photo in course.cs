using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class addfieldphotoincourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Courses",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 3, 16, 48, 32, 649, DateTimeKind.Local).AddTicks(6623), new DateTime(2020, 3, 3, 16, 48, 32, 649, DateTimeKind.Local).AddTicks(7584) });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 3, 16, 48, 32, 652, DateTimeKind.Local).AddTicks(8952), new DateTime(2020, 3, 3, 16, 48, 32, 653, DateTimeKind.Local).AddTicks(220) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Photo", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 3, 16, 48, 32, 650, DateTimeKind.Local).AddTicks(5912), "react.png", new DateTime(2020, 3, 3, 16, 48, 32, 650, DateTimeKind.Local).AddTicks(6840) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 3, 16, 48, 32, 654, DateTimeKind.Local).AddTicks(2960), new DateTime(2020, 3, 3, 16, 48, 32, 654, DateTimeKind.Local).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 3, 16, 48, 32, 654, DateTimeKind.Local).AddTicks(4950), new DateTime(2020, 3, 3, 16, 48, 32, 654, DateTimeKind.Local).AddTicks(4959) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 3, 16, 48, 32, 654, DateTimeKind.Local).AddTicks(4970), new DateTime(2020, 3, 3, 16, 48, 32, 654, DateTimeKind.Local).AddTicks(4971) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 3, 16, 48, 32, 654, DateTimeKind.Local).AddTicks(4974), new DateTime(2020, 3, 3, 16, 48, 32, 654, DateTimeKind.Local).AddTicks(4977) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 3, 16, 48, 32, 653, DateTimeKind.Local).AddTicks(5408), new DateTime(2020, 3, 3, 16, 48, 32, 653, DateTimeKind.Local).AddTicks(6565) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 3, 16, 48, 32, 652, DateTimeKind.Local).AddTicks(2161), new DateTime(2020, 3, 3, 16, 48, 32, 652, DateTimeKind.Local).AddTicks(3055) });

            migrationBuilder.UpdateData(
                table: "UserContents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 3, 16, 48, 32, 654, DateTimeKind.Local).AddTicks(8539));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 3, 16, 48, 32, 646, DateTimeKind.Local).AddTicks(2766), new DateTime(2020, 3, 3, 16, 48, 32, 649, DateTimeKind.Local).AddTicks(1196) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 3, 16, 48, 32, 651, DateTimeKind.Local).AddTicks(5865), new DateTime(2020, 3, 3, 16, 48, 32, 651, DateTimeKind.Local).AddTicks(6874) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Courses");

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
    }
}
