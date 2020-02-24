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
    public class QuestionQuerys : IQuestionQueries
    {
        protected readonly ApplicationDbContext _context;

        public QuestionQuerys(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionViewModel>> FindAllAsync()
        {
            return await _context.Questions.AsNoTracking()
                .Include(c => c.Course)
                .Select(c => new QuestionViewModel
                {
                    Id = c.Id,
                    Content = c.Content,
                    CourseId = c.CourseId,
                    CourseName = c.Course.Name,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<QuestionViewModel> FindByIdAsync(int id)
        {
            return await _context.Questions.AsNoTracking()
                .Include(c => c.Course)
                .Select(c => new QuestionViewModel
                {
                    Id = c.Id,
                    Content = c.Content,
                    CourseId = c.CourseId,
                    CourseName = c.Course.Name,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .FirstOrDefaultAsync(question => question.Id == id);
        }

        public async Task<List<QuestionViewModel>> GetAllByCourseIdAsync(int courseid)
        {
            return await _context.Questions.AsNoTracking()
                .Include(c => c.Course)
                .Select(c => new QuestionViewModel
                {
                    Id = c.Id,
                    Content = c.Content,
                    CourseId = c.CourseId,
                    CourseName = c.Course.Name,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .Where(question => question.CourseId == courseid).ToListAsync();
        }

        public async Task<List<QuestionViewModel>> GetQuestionExamAsync(int courseid)
        {
            return await _context.Questions.AsNoTracking()
                .Include(c => c.Course)
                .Select(c => new QuestionViewModel
                {
                    Id = c.Id,
                    Content = c.Content,
                    CourseId = c.CourseId,
                    CourseName = c.Course.Name,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .Where(question => question.CourseId == courseid)
                .OrderBy(r => Guid.NewGuid()).Skip(1).Take(5)
                .ToListAsync();
        }
    }
}
