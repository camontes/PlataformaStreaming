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
    [Migration("20191109031254_UpdateCategoriesSeed")]
    partial class UpdateCategoriesSeed
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
                            CreatedAt = new DateTime(2019, 11, 8, 22, 12, 53, 406, DateTimeKind.Local).AddTicks(172),
                            Description = "En esta categoria encontrarás cursos de Blender y Unreal",
                            IsActive = true,
                            Name = "Video Juegos",
                            UpdatedAt = new DateTime(2019, 11, 8, 22, 12, 53, 406, DateTimeKind.Local).AddTicks(1708)
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
                            CreatedAt = new DateTime(2019, 11, 8, 22, 12, 53, 402, DateTimeKind.Local).AddTicks(5669),
                            Email = "sample@email.com",
                            IsActive = true,
                            LastName = "Sample",
                            Name = "Mr.",
                            Photo = "photo.png",
                            UpdatedAt = new DateTime(2019, 11, 8, 22, 12, 53, 405, DateTimeKind.Local).AddTicks(782)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}