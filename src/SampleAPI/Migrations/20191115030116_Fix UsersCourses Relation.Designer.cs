﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleAPI.Infrastructure;

namespace SampleAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191115030116_Fix UsersCourses Relation")]
    partial class FixUsersCoursesRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SampleAPI.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2019, 11, 14, 22, 1, 15, 515, DateTimeKind.Local).AddTicks(6040),
                            Description = "En esta categoria encontrarás cursos de Blender y Unreal",
                            IsActive = true,
                            Name = "Video Juegos",
                            UpdatedAt = new DateTime(2019, 11, 14, 22, 1, 15, 515, DateTimeKind.Local).AddTicks(6816)
                        });
                });

            modelBuilder.Entity("SampleAPI.Domain.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2019, 11, 14, 22, 1, 15, 516, DateTimeKind.Local).AddTicks(3014),
                            Description = "En esta categoria encontrarás temas de Blender",
                            IsActive = true,
                            Name = "Blender",
                            UpdatedAt = new DateTime(2019, 11, 14, 22, 1, 15, 516, DateTimeKind.Local).AddTicks(3946)
                        });
                });

            modelBuilder.Entity("SampleAPI.Domain.Models.UserCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<bool>("IsEnd");

                    b.Property<float>("Rating");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("Username");

                    b.ToTable("UsersCourses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            CreatedAt = new DateTime(2019, 11, 14, 22, 1, 15, 516, DateTimeKind.Local).AddTicks(8976),
                            IsEnd = false,
                            Rating = 0f,
                            UpdatedAt = new DateTime(2019, 11, 14, 22, 1, 15, 517, DateTimeKind.Local).AddTicks(285),
                            Username = "Mr. Sample"
                        });
                });

            modelBuilder.Entity("SampleAPI.Domain.User", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Username");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Username = "Mr. Sample",
                            CreatedAt = new DateTime(2019, 11, 14, 22, 1, 15, 512, DateTimeKind.Local).AddTicks(7729),
                            Email = "sample@email.com",
                            IsActive = true,
                            LastName = "Sample",
                            Name = "Mr.",
                            Photo = "photo.png",
                            UpdatedAt = new DateTime(2019, 11, 14, 22, 1, 15, 515, DateTimeKind.Local).AddTicks(1277)
                        });
                });

            modelBuilder.Entity("SampleAPI.Domain.Course", b =>
                {
                    b.HasOne("SampleAPI.Domain.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SampleAPI.Domain.Models.UserCourse", b =>
                {
                    b.HasOne("SampleAPI.Domain.Course", "Course")
                        .WithMany("UserCourse")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SampleAPI.Domain.User", "User")
                        .WithMany("UserCourse")
                        .HasForeignKey("Username");
                });
#pragma warning restore 612, 618
        }
    }
}
