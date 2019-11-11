using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class AddNewCourseFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 10, 18, 17, 59, 988, DateTimeKind.Local).AddTicks(9439), new DateTime(2019, 11, 10, 18, 17, 59, 989, DateTimeKind.Local).AddTicks(668) });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseId", "CreatedAt", "Description", "IsActive", "Name", "UpdatedAt" },
                values: new object[] { 1, 1, new DateTime(2019, 11, 10, 18, 17, 59, 989, DateTimeKind.Local).AddTicks(6938), "En esta categoria encontrarás temas de Blender", true, "Blender", new DateTime(2019, 11, 10, 18, 17, 59, 989, DateTimeKind.Local).AddTicks(8022) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 10, 18, 17, 59, 985, DateTimeKind.Local).AddTicks(3338), new DateTime(2019, 11, 10, 18, 17, 59, 988, DateTimeKind.Local).AddTicks(2693) });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseId",
                table: "Courses",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 9, 0, 26, 5, 756, DateTimeKind.Local).AddTicks(9669), new DateTime(2019, 11, 9, 0, 26, 5, 757, DateTimeKind.Local).AddTicks(629) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 9, 0, 26, 5, 754, DateTimeKind.Local).AddTicks(8222), new DateTime(2019, 11, 9, 0, 26, 5, 756, DateTimeKind.Local).AddTicks(3505) });
        }
    }
}
