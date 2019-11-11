using Microsoft.EntityFrameworkCore;
using SampleAPI.Domain;
using SampleAPI.Infrastructure;
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

        public async Task<List<Course>> FindAllAsync()
        {
            return await _context.Courses.AsNoTracking().ToListAsync();
        }

        public async Task<Course> FindByIdAsync(int id)
        {
            return await _context.Courses.AsNoTracking().FirstOrDefaultAsync(course => course.Id == id);
        }

        //public async Task<List<Course>> FindAllByCategoryIdAsync(int CategoryId)
        //{
        //    return await _context.Courses.AsNoTracking().Where(course => course.CategoryId == CategoryId).ToListAsync();
        //}

    }
}