﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<UserContent> FindUserContentAsync(int id, string username)
        {
            return await _context.UserContents.AsNoTracking()
                .FirstOrDefaultAsync(usercontent => usercontent.Username == username && usercontent.ContentId == id);
        }

        public async Task<List<BasicUserContentViewModel>> FindAllUserContentAsync()
        {
            return await _context.UserContents.AsNoTracking()
                .Select(c => new BasicUserContentViewModel
                {
                    Username = c.Username,
                    ContentId = c.ContentId
                })
                .ToListAsync();
        }
    }
}