using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAPI.Migrations
{
    public partial class deletemethodsofseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1);

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

            migrationBuilder.DeleteData(
                table: "UserContents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UsersCourses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 10, 9, 42, 32, 496, DateTimeKind.Local).AddTicks(2917), new DateTime(2020, 3, 10, 9, 42, 32, 498, DateTimeKind.Local).AddTicks(1851) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "Name", "Photo", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2020, 3, 9, 15, 27, 40, 655, DateTimeKind.Local).AddTicks(5346), "En esta categoria encontrarás cursos de Blender y Unreal", true, "Video Juegos", "dsfdfdfggggg", new DateTime(2020, 3, 9, 15, 27, 40, 655, DateTimeKind.Local).AddTicks(6102) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr. Sample",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 3, 9, 15, 27, 40, 652, DateTimeKind.Local).AddTicks(4078), new DateTime(2020, 3, 9, 15, 27, 40, 654, DateTimeKind.Local).AddTicks(2436) });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "IsActive", "IsPublished", "Name", "Photo", "PostedAt", "Rating", "UpdatedAt", "Username" },
                values: new object[] { 1, 1, new DateTime(2020, 3, 9, 15, 27, 40, 656, DateTimeKind.Local).AddTicks(1767), "En esta categoria encontrarás temas de Blender", true, false, "Blender", "react.png", null, 0.0, new DateTime(2020, 3, 9, 15, 27, 40, 656, DateTimeKind.Local).AddTicks(2496), "Mr. Sample" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "CourseId", "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { 1, "Pregunta Curso 1", 1, new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(3725), true, new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(4435) });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CourseId", "CreatedAt", "IsActive", "Name", "UpdatedAt" },
                values: new object[] { 1, 1, new DateTime(2020, 3, 9, 15, 27, 40, 657, DateTimeKind.Local).AddTicks(4066), true, "Tema1 Blender", new DateTime(2020, 3, 9, 15, 27, 40, 657, DateTimeKind.Local).AddTicks(4924) });

            migrationBuilder.InsertData(
                table: "UsersCourses",
                columns: new[] { "Id", "CorrectAnswers", "CourseId", "CreatedAt", "IsEnd", "Progress", "Rating", "UpdatedAt", "Username" },
                values: new object[] { 1, 0, 1, new DateTime(2020, 3, 9, 15, 27, 40, 656, DateTimeKind.Local).AddTicks(9124), false, 0, 0, new DateTime(2020, 3, 9, 15, 27, 40, 656, DateTimeKind.Local).AddTicks(9658), "Mr. Sample" });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name", "SubjectId", "UpdatedAt", "Url" },
                values: new object[] { 1, new DateTime(2020, 3, 9, 15, 27, 40, 657, DateTimeKind.Local).AddTicks(9170), true, "Contenido Tema1", 1, new DateTime(2020, 3, 9, 15, 27, 40, 657, DateTimeKind.Local).AddTicks(9943), "www.google.com" });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Content", "CreatedAt", "IsActive", "IsCorrect", "QuestionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Respuesta Pregunta 1", new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(8561), true, true, 1, new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(9239) },
                    { 2, "Respuesta Pregunta 2", new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(9949), true, false, 1, new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(9955) },
                    { 3, "Respuesta Pregunta 3", new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(9964), true, false, 1, new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(9965) },
                    { 4, "Respuesta Pregunta 4", new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(9968), true, false, 1, new DateTime(2020, 3, 9, 15, 27, 40, 658, DateTimeKind.Local).AddTicks(9970) }
                });

            migrationBuilder.InsertData(
                table: "UserContents",
                columns: new[] { "Id", "ContentId", "CreatedAt", "Username" },
                values: new object[] { 1, 1, new DateTime(2020, 3, 9, 15, 27, 40, 659, DateTimeKind.Local).AddTicks(2305), "Mr. Sample" });
        }
    }
}
