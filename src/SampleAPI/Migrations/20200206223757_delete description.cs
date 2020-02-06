using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class deletedescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Contents");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Subjects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Contents",
                nullable: true);

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
                columns: new[] { "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 35, 38, 824, DateTimeKind.Local).AddTicks(8941), "Descripcion Contenido Tema1", new DateTime(2020, 2, 6, 17, 35, 38, 824, DateTimeKind.Local).AddTicks(9650) });

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
                columns: new[] { "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 2, 6, 17, 35, 38, 824, DateTimeKind.Local).AddTicks(3116), "Descripcion Tema1 Blender", new DateTime(2020, 2, 6, 17, 35, 38, 824, DateTimeKind.Local).AddTicks(3950) });

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
    }
}
