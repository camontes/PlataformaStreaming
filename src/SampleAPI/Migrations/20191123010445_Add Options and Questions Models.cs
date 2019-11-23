using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class AddOptionsandQuestionsModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsCorrect = table.Column<bool>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "CourseId", "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { 1, "Pregunta Curso 1", 1, new DateTime(2019, 11, 22, 20, 4, 43, 196, DateTimeKind.Local).AddTicks(981), true, new DateTime(2019, 11, 22, 20, 4, 43, 196, DateTimeKind.Local).AddTicks(3359) });

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

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Content", "CreatedAt", "IsActive", "IsCorrect", "QuestionId", "UpdatedAt" },
                values: new object[] { 1, "Pregunta Curso 1", new DateTime(2019, 11, 22, 20, 4, 43, 199, DateTimeKind.Local).AddTicks(2467), true, true, 1, new DateTime(2019, 11, 22, 20, 4, 43, 200, DateTimeKind.Local).AddTicks(274) });

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CourseId",
                table: "Questions",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 20, 20, 18, 44, 778, DateTimeKind.Local).AddTicks(3770), new DateTime(2019, 11, 20, 20, 18, 44, 778, DateTimeKind.Local).AddTicks(4607) });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 20, 20, 18, 44, 781, DateTimeKind.Local).AddTicks(1827), new DateTime(2019, 11, 20, 20, 18, 44, 781, DateTimeKind.Local).AddTicks(2645) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 20, 20, 18, 44, 779, DateTimeKind.Local).AddTicks(1543), new DateTime(2019, 11, 20, 20, 18, 44, 779, DateTimeKind.Local).AddTicks(3991) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 20, 20, 18, 44, 780, DateTimeKind.Local).AddTicks(4833), new DateTime(2019, 11, 20, 20, 18, 44, 780, DateTimeKind.Local).AddTicks(5941) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 20, 20, 18, 44, 776, DateTimeKind.Local).AddTicks(1219), new DateTime(2019, 11, 20, 20, 18, 44, 777, DateTimeKind.Local).AddTicks(8887) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 20, 20, 18, 44, 779, DateTimeKind.Local).AddTicks(9280), new DateTime(2019, 11, 20, 20, 18, 44, 780, DateTimeKind.Local).AddTicks(79) });
        }
    }
}
