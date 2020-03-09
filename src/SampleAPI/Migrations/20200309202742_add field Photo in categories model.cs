using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class addfieldPhotoincategoriesmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Categories",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Photo", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 9, 15, 27, 40, 655, DateTimeKind.Local).AddTicks(5346), "dsfdfdfggggg", new DateTime(2020, 3, 9, 15, 27, 40, 655, DateTimeKind.Local).AddTicks(6102) });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 9, 15, 27, 40, 657, DateTimeKind.Local).AddTicks(9170), new DateTime(2020, 3, 9, 15, 27, 40, 657, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 9, 15, 27, 40, 656, DateTimeKind.Local).AddTicks(1767), new DateTime(2020, 3, 9, 15, 27, 40, 656, DateTimeKind.Local).AddTicks(2496) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(8561), new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(9239) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(9949), new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(9955) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(9964), new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(9965) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(9968), new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(9970) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(3725), new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(4435) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 9, 15, 27, 40, 657, DateTimeKind.Local).AddTicks(4066), new DateTime(2020, 3, 9, 15, 27, 40, 657, DateTimeKind.Local).AddTicks(4924) });

            migrationBuilder.UpdateData(
                table: "UserContents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 15, 27, 40, 659, DateTimeKind.Local).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 9, 15, 27, 40, 652, DateTimeKind.Local).AddTicks(4078), new DateTime(2020, 3, 9, 15, 27, 40, 654, DateTimeKind.Local).AddTicks(2436) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 9, 15, 27, 40, 656, DateTimeKind.Local).AddTicks(9124), new DateTime(2020, 3, 9, 15, 27, 40, 656, DateTimeKind.Local).AddTicks(9658) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Categories");

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 3, 16, 48, 32, 650, DateTimeKind.Local).AddTicks(5912), new DateTime(2020, 3, 3, 16, 48, 32, 650, DateTimeKind.Local).AddTicks(6840) });

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
    }
}
