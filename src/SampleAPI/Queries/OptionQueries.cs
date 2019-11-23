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
    public class OptionQuerys : IOptionQueries
    {
        protected readonly ApplicationDbContext _context;

        public OptionQuerys(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OptionViewModel>> FindAllAsync()
        {
            return await _context.Options.AsNoTracking()
                .Include(c => c.Question)
                .Select(c => new OptionViewModel
                {
                    Id = c.Id,
                    Content = c.Content,
                    IsCorrect = c.IsCorrect,
                    IsActive = c.IsActive,
                    QuestionId = c.QuestionId,
                    QuestionContent = c.Question.Content,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<OptionViewModel> FindByIdAsync(int id)
        {
            return await _context.Options.AsNoTracking()
                .Include(c => c.Question)
                .Select(c => new OptionViewModel
                {
                    Id = c.Id,
                    Content = c.Content,
                    IsCorrect = c.IsCorrect,
                    IsActive = c.IsActive,
                    QuestionId = c.QuestionId,
                    QuestionContent = c.Question.Content,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .FirstOrDefaultAsync(option => option.Id == id);
        }

        public async Task<List<OptionViewModel>> GetAllByQuestionIdAsync(int questionid)
        {
            return await _context.Options.AsNoTracking()
                .Include(c => c.Question)
                .Select(c => new OptionViewModel
                {
                    Id = c.Id,
                    Content = c.Content,
                    IsCorrect = c.IsCorrect,
                    IsActive = c.IsActive,
                    QuestionId = c.QuestionId,
                    QuestionContent = c.Question.Content,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .Where(option => option.QuestionId == questionid).ToListAsync();
        }
    }
}
