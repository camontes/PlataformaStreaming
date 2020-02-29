using Microsoft.EntityFrameworkCore;
using SampleAPI.Domain.Models;
using SampleAPI.Infrastructure;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public class UserContentQueries : IUserContentQueries
    {
        protected readonly ApplicationDbContext _context;

        public UserContentQueries(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CountByContentAsync(int courseid, string username)
        {
            return await _context.UserContents.AsNoTracking()
                .Where(usercontent => usercontent.Username == username && usercontent.Content.Subject.CourseId == courseid)
                .CountAsync();
        }

        public async Task<BasicUserContentViewModel> FindUserContentAsync(int id, string username)
        {
            return await _context.UserContents.AsNoTracking()
                 .Include(c => c.Content)
                 .Select(c => new BasicUserContentViewModel
                 {
                     Id = c.Id,
                     Username = c.Username,
                     ContentId = c.ContentId,
                     CreatedAt = c.CreatedAt,
                     CourseId = c.Content.Subject.CourseId
                 })
                .FirstOrDefaultAsync(usercontent => usercontent.Username == username && usercontent.ContentId == id);
        }

        public async Task<List<BasicUserContentViewModel>> FindAllUserContentAsync()
        {
            return await _context.UserContents.AsNoTracking()
                .Include(c => c.Content)
                .Select(c => new BasicUserContentViewModel
                {
                    Id = c.Id,
                    Username = c.Username,
                    ContentId = c.ContentId,
                    CreatedAt = c.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<List<BasicUserContentViewModel>> FindAllUserContenByUsernameAsync(string username)
        {
            return await _context.UserContents.AsNoTracking()
                .Include(c => c.Content)
                .Select(c => new BasicUserContentViewModel
                {
                    Id = c.Id,
                    Username = c.Username,
                    ContentId = c.ContentId,
                    CreatedAt = c.CreatedAt,
                    CourseId = c.Content.Subject.CourseId
                })
                .Where(userContent => userContent.Username == username)
                .ToListAsync();
        }

        public async Task<BasicUserContentViewModel> FindUserContenByUsernameContentAsync(int contentId,string username)
        {
            return await _context.UserContents.AsNoTracking()
                 .Include(c => c.Content)
                .Select(c => new BasicUserContentViewModel
                {
                    Id = c.Id,
                    Username = c.Username,
                    ContentId = c.ContentId,
                    CreatedAt = c.CreatedAt,
                    CourseId = c.Content.Subject.CourseId
                })
                .FirstOrDefaultAsync(userContent => userContent.Username == username && userContent.ContentId == contentId);
        }

        public async Task<BasicUserContentViewModel> FindByIdAsync(int id)
        {
            return await _context.UserContents.AsNoTracking()
                .Include(c => c.Content)
                .Select(c => new BasicUserContentViewModel
                {
                    Id = c.Id,
                    Username = c.Username,
                    ContentId = c.ContentId,
                    CreatedAt = c.CreatedAt,
                    CourseId = c.Content.Subject.CourseId
                })
                .FirstOrDefaultAsync(userContent => userContent.Id == id);
        }

        public async Task<BasicUserContentViewModel> FindLastUserContentAsync(int courseId, string username)
        {
            return await _context.UserContents.AsNoTracking()
                .Include(c => c.Content)
                .Select(c => new BasicUserContentViewModel
                {
                    Id = c.Id,
                    Username = c.Username,
                    ContentId = c.ContentId,
                    CreatedAt = c.CreatedAt,
                    CourseId = c.Content.Subject.CourseId
                })
                .OrderByDescending(userContent => userContent.CreatedAt)
                .FirstOrDefaultAsync(userContent => userContent.Username == username && userContent.CourseId == courseId);
        }
    }
}
