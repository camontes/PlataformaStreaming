using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class UsersCoursesRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    IsEnd = table.Column<bool>(nullable: false),
                    Rating = table.Column<float>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersCourses_Users_Username",
                        column: x => x.Username,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 14, 21, 54, 4, 242, DateTimeKind.Local).AddTicks(6098), new DateTime(2019, 11, 14, 21, 54, 4, 242, DateTimeKind.Local).AddTicks(7331) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 14, 21, 54, 4, 243, DateTimeKind.Local).AddTicks(4099), new DateTime(2019, 11, 14, 21, 54, 4, 243, DateTimeKind.Local).AddTicks(8842) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 14, 21, 54, 4, 239, DateTimeKind.Local).AddTicks(4358), new DateTime(2019, 11, 14, 21, 54, 4, 241, DateTimeKind.Local).AddTicks(6819) });

            migrationBuilder.CreateIndex(
                name: "IX_UsersCourses_CourseId",
                table: "UsersCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCourses_Username",
                table: "UsersCourses",
                column: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersCourses");

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
        }
    }
}
