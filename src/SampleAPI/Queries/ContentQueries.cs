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
                    Url = c.Url,
                    IsActive = c.IsActive,
                    SubjectId = c.SubjectId,
                    CourseId=c.Subject.CourseId,
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
                    Url = c.Url,
                    IsActive = c.IsActive,
                    SubjectId = c.SubjectId,
                    CourseId = c.Subject.CourseId,
                    SubjectName = c.Subject.Name,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .FirstOrDefaultAsync(content => content.Id == id);
        }

        public async Task<List<ContentViewModel>> GetAllBySubjectIdAsync(int subjectid)
        {
            return await _context.Contents.AsNoTracking()
                .Include(c => c.Subject)
                .Select(c => new ContentViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Url = c.Url,
                    IsActive = c.IsActive,
                    SubjectId = c.SubjectId,
                    CourseId = c.Subject.CourseId,
                    SubjectName = c.Subject.Name,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .Where(content => content.SubjectId == subjectid).ToListAsync();
        }

        public async Task<List<ContentViewModel>> GetAllByCourseIdAsync(int courseId)
        {
            return await _context.Contents.AsNoTracking()
                .Include(c => c.Subject)
                .Select(c => new ContentViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Url = c.Url,
                    IsActive = c.IsActive,
                    SubjectId = c.SubjectId,
                    CourseId = c.Subject.CourseId,
                    SubjectName = c.Subject.Name,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .Where(content => content.CourseId == courseId).ToListAsync();
        }

        public async Task<int> CountByCourseIdAsync(int courseid)
        {
            return await _context.Contents.AsNoTracking()
                .Where(content => content.Subject.CourseId == courseid)
                .CountAsync();
        }

    }
}