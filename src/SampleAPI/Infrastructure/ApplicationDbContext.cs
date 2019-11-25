using Microsoft.EntityFrameworkCore;
using SampleAPI.Domain;
using SampleAPI.Domain.Models;

namespace SampleAPI.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<UserCourse> UsersCourses { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Content> Contents { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Option> Options { get; set; }

        public DbSet<UserContent> UserContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
