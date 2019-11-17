using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class migrationAddSubjectandContentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
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
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Contents_SubjectId",
                table: "Contents",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CourseId",
                table: "Subjects",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 14, 22, 1, 15, 515, DateTimeKind.Local).AddTicks(6040), new DateTime(2019, 11, 14, 22, 1, 15, 515, DateTimeKind.Local).AddTicks(6816) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 14, 22, 1, 15, 516, DateTimeKind.Local).AddTicks(3014), new DateTime(2019, 11, 14, 22, 1, 15, 516, DateTimeKind.Local).AddTicks(3946) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 14, 22, 1, 15, 512, DateTimeKind.Local).AddTicks(7729), new DateTime(2019, 11, 14, 22, 1, 15, 515, DateTimeKind.Local).AddTicks(1277) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 14, 22, 1, 15, 516, DateTimeKind.Local).AddTicks(8976), new DateTime(2019, 11, 14, 22, 1, 15, 517, DateTimeKind.Local).AddTicks(285) });
        }
    }
}
