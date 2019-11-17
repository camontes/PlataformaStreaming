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
    public class ContentQuerys : IContentQueries
    {
        protected readonly ApplicationDbContext _context;

        public ContentQuerys(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContentViewModel>> FindAllAsync()
        {
            return await _context.Contents.AsNoTracking()
                .Include(c => c.Subject)
                .Select(c => new ContentViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Url = c.Url,
                    IsActive = c.IsActive,
                    SubjectId = c.SubjectId,
                    SubjectName = c.Subject.Name,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<ContentViewModel> FindByIdAsync(int id)
        {
            return await _context.Contents.AsNoTracking()
                .Include(c => c.Subject)
                .Select(c => new ContentViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Url = c.Url,
                    IsActive = c.IsActive,
                    SubjectId = c.SubjectId,
                    SubjectName = c.Subject.Name,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .FirstOrDefaultAsync(content => content.Id == id);
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