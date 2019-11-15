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
    public class UserCourseQuerys : IUserCourseQueries
    {
        protected readonly ApplicationDbContext _context;

        public UserCourseQuerys(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserCourseViewModel>> FindAllAsync()
        {
            return await _context.UsersCourses.AsNoTracking()
                .Include(c => c.Course)
                .Include(c => c.User)
                .Select(c => new UserCourseViewModel
                {
                    Id = c.Id,
                    CourseId = c.CourseId,
                    CourseName = c.Course.Name,
                    Username = c.Username,
                    IsEnd = c.IsEnd,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<UserCourseViewModel> FindByIdAsync(int id)
        {
            return await _context.UsersCourses.AsNoTracking()
                .Include(c => c.Course)
                .Include(c => c.User)
                .Select(c => new UserCourseViewModel
                {
                    Id = c.Id,
                    CourseId = c.CourseId,
                    CourseName = c.Course.Name,
                    Username = c.Username,
                    IsEnd = c.IsEnd,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .FirstOrDefaultAsync(usercourse => usercourse.Id == id);
        }

        //public async Task<List<CourseViewModel>> GetAllByCategoryIdAsync(int categoryid)
        //{
        //    return await _context.Courses.AsNoTracking()
        //        .Include(c => c.Category)
        //        .Select(c => new CourseViewModel
        //        {
        //            Id = c.Id,
        //            Name = c.Name,
        //            Description = c.Description,
        //            IsActive = c.IsActive,
        //            CategoryId = c.CategoryId,
        //            CategoryName = c.Category.Name,
        //            CreatedAt = c.CreatedAt,
        //            UpdatedAt = c.UpdatedAt
        //        })
        //        .Where(course => course.CategoryId == categoryid).ToListAsync();
        //}

    }
}