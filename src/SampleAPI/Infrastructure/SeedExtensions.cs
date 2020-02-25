using Microsoft.EntityFrameworkCore;
using SampleAPI.Domain;
using SampleAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPI.Infrastructure
{
    public static class SeedExtensions
    {
        public static readonly User[] UsersSeed = new User[] {
            new User
            {
                Username = "Mr. Sample",
                Email = "sample@email.com",
                Name="Mr.",
                LastName="Sample",
                Photo="photo.png",
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };

        public static readonly Category[] CategoriesSeed = new Category[] {
            new Category
            {
                Id=1,
                Name="Video Juegos",
                Description="En esta categoria encontrarás cursos de Blender y Unreal",
                IsActive=true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };

        public static readonly Course[] CoursesSeed = new Course[] {
            new Course
            {
                Id=1,
                Name="Blender",
                Description="En esta categoria encontrarás temas de Blender",
                Username="Mr. Sample",
                IsActive=true,
                CategoryId=1,
                Rating=0,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                PostedAt = null,
                IsPublished = false
            }
        };

        public static readonly UserCourse[] UsersCoursesSeed = new UserCourse[] {
            new UserCourse
            {
                Id=1,
                CourseId=1,
                Username="Mr. Sample",
                IsEnd=false,
                Rating=0,
                Progress=0,
                CorrectAnswers = 0,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };

        public static readonly Subject[] SubjectsSeed = new Subject[] {
            new Subject
            {
               Id=1,
               Name="Tema1 Blender",
               IsActive=true,
               CourseId=1,
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now
            }
        };

        public static readonly Content[] ContentsSeed = new Content[] {
            new Content
            {
               Id=1,
               Name="Contenido Tema1",
               Url="www.google.com",
               IsActive=true,
               SubjectId=1,
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now
            }
        };

        public static readonly Question[] QuestionsSeed = new Question[] {
            new Question
            {
               Id=1,
               Content="Pregunta Curso 1",
               IsActive=true,
               CourseId=1,
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now
            }
        };

        public static readonly Option[] OptionsSeed = new Option[] {
            new Option
            {
               Id=1,
               Content="Respuesta Pregunta 1",
               IsActive=true,
               QuestionId=1,
               IsCorrect=true,
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now
            },
            new Option
            {
               Id=2,
               Content="Respuesta Pregunta 2",
               IsActive=true,
               QuestionId=1,
               IsCorrect=false,
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now
            },
            new Option
            {
               Id=3,
               Content="Respuesta Pregunta 3",
               IsActive=true,
               QuestionId=1,
               IsCorrect=false,
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now
            },
            new Option
            {
               Id=4,
               Content="Respuesta Pregunta 4",
               IsActive=true,
               QuestionId=1,
               IsCorrect=false,
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now
            }
        };

        public static readonly UserContent[] UserContentsSeed = new UserContent[] {
            new UserContent
            {
               Id=1,
               Username="Mr. Sample",
               ContentId=1,
               CreatedAt = DateTime.Now,
            }
        };
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               UsersSeed
            );
            modelBuilder.Entity<Category>().HasData(
               CategoriesSeed
            );
            modelBuilder.Entity<Course>().HasData(
               CoursesSeed
            );

            modelBuilder.Entity<UserCourse>().HasData(
               UsersCoursesSeed
            );

            modelBuilder.Entity<Subject>().HasData(
              SubjectsSeed
           );

            modelBuilder.Entity<Content>().HasData(
              ContentsSeed
           );

            modelBuilder.Entity<Question>().HasData(
              QuestionsSeed
           );

            modelBuilder.Entity<Option>().HasData(
              OptionsSeed
           );

            modelBuilder.Entity<UserContent>().HasData(
              UserContentsSeed
           );
        }
    }
}
