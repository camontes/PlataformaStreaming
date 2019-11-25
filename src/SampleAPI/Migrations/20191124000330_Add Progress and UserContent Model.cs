using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class AddProgressandUserContentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "UsersCourses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserContents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    ContentId = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContents_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserContents_Users_Username",
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
                values: new object[] { new DateTime(2019, 11, 23, 19, 3, 28, 91, DateTimeKind.Local).AddTicks(5033), new DateTime(2019, 11, 23, 19, 3, 28, 91, DateTimeKind.Local).AddTicks(6027) });

            migrationBuilder.UpdateData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 23, 19, 3, 28, 96, DateTimeKind.Local).AddTicks(8711), new DateTime(2019, 11, 23, 19, 3, 28, 96, DateTimeKind.Local).AddTicks(9869) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 23, 19, 3, 28, 92, DateTimeKind.Local).AddTicks(2084), new DateTime(2019, 11, 23, 19, 3, 28, 92, DateTimeKind.Local).AddTicks(3194) });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 23, 19, 3, 28, 99, DateTimeKind.Local).AddTicks(2502), new DateTime(2019, 11, 23, 19, 3, 28, 101, DateTimeKind.Local).AddTicks(6376) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 23, 19, 3, 28, 97, DateTimeKind.Local).AddTicks(7414), new DateTime(2019, 11, 23, 19, 3, 28, 97, DateTimeKind.Local).AddTicks(8387) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 23, 19, 3, 28, 96, DateTimeKind.Local).AddTicks(514), new DateTime(2019, 11, 23, 19, 3, 28, 96, DateTimeKind.Local).AddTicks(1948) });

            migrationBuilder.InsertData(
                table: "UserContents",
                columns: new[] { "Id", "ContentId", "CreatedAt", "Username" },
                values: new object[] { 1, 1, new DateTime(2019, 11, 23, 19, 3, 28, 102, DateTimeKind.Local).AddTicks(1849), "Mr. Sample" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 23, 19, 3, 28, 88, DateTimeKind.Local).AddTicks(1277), new DateTime(2019, 11, 23, 19, 3, 28, 90, DateTimeKind.Local).AddTicks(9111) });

            migrationBuilder.UpdateData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 23, 19, 3, 28, 94, DateTimeKind.Local).AddTicks(3049), new DateTime(2019, 11, 23, 19, 3, 28, 94, DateTimeKind.Local).AddTicks(9038) });

            migrationBuilder.CreateIndex(
                name: "IX_UserContents_ContentId",
                table: "UserContents",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContents_Username",
                table: "UserContents",
                column: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserContents");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "UsersCourses");

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2019, 11, 22, 22, 11, 47, 177, DateTimeKind.Local).AddTicks(1333), new DateTime(2019, 11, 22, 22, 11, 47, 177, DateTimeKind.Local).AddTicks(5009) });

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
    }
}
