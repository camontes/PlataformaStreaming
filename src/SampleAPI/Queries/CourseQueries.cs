using Microsoft.EntityFrameworkCore;
using SampleAPI.Domain;
using SampleAPI.Infrastructure;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public class CourseQuerys : ICourseQueries
    {
        protected readonly ApplicationDbContext _context;

        public CourseQuerys(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CourseViewModel>> FindAllAsync()
        {
            return await _context.Courses.AsNoTracking()
                .Include(c => c.Category)
                .Include(c => c.User)
                .Select(c => new CourseViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Photo = c.Photo,
                    IsActive = c.IsActive,
                    Username = c.User.Username,
                    NameTeacher = c.User.Name,
                    EmailTeacher = c.User.Username,
                    PhotoTeacher = c.User.Photo,
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category.Name,
                    Rating = c.Rating,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt,
                    PostedAt = c.PostedAt,
                    IsPublished = c.IsPublished
                }).Where(course => course.IsPublished == true)
                   .ToListAsync();
        }

        public async Task<CourseViewModel> FindByIdAsync(int id)
        {
            return await _context.Courses.AsNoTracking()
                .Include(c => c.Category)
                .Include(c => c.User)
                .Select(c => new CourseViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Photo = c.Photo,
                    IsActive = c.IsActive,
                    Username = c.User.Username,
                    NameTeacher = c.User.Name,
                    EmailTeacher = c.User.Username,
                    PhotoTeacher = c.User.Photo,
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category.Name,
                    Rating = c.Rating,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt,
                    PostedAt = c.PostedAt,
                    IsPublished = c.IsPublished
                })
                .FirstOrDefaultAsync(course => course.Id == id);
        }

        public async Task<List<CourseViewModel>> GetAllByCategoryIdAsync(int categoryid)
        {
            return await _context.Courses.AsNoTracking()
                .Include(c => c.Category)
                .Include(c => c.User)
                .Select(c => new CourseViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Photo = c.Photo,
                    IsActive = c.IsActive,
                    Username = c.User.Username,
                    NameTeacher = c.User.Name,
                    EmailTeacher = c.User.Username,
                    PhotoTeacher = c.User.Photo,
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category.Name,
                    Rating = c.Rating,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt,
                    PostedAt = c.PostedAt,
                    IsPublished = c.IsPublished
                })
                .Where(course => course.CategoryId == categoryid && course.IsPublished == true).ToListAsync();
        }

        public async Task<List<CourseViewModel>> GetAllByUsernameAsync(string username)
        {
            return await _context.Courses.AsNoTracking()
                .Include(c => c.Category)
                .Include(c => c.User)
                .Select(c => new CourseViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Photo = c.Photo,
                    IsActive = c.IsActive,
                    Username = c.User.Username,
                    NameTeacher = c.User.Name,
                    EmailTeacher = c.User.Username,
                    PhotoTeacher = c.User.Photo,
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category.Name,
                    Rating = c.Rating,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt,
                    PostedAt = c.PostedAt,
                    IsPublished = c.IsPublished
                })
                .Where(course => course.Username == username).ToListAsync();
        }

    }
}