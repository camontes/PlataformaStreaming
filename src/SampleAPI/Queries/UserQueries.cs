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
    public class UserQueries : IUserQueries
    {
        protected readonly ApplicationDbContext _context;

        public UserQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserViewModel>> FindAllAsync()
        {
            return await _context.Users.AsNoTracking()
                .Select(c => new UserViewModel
                {
                   Username=c.Username,
                   Name=c.Name,
                   LastName=c.LastName,
                   Photo=c.Photo,
                   Email=c.Email,
                   IsActive=c.IsActive,
                   CreatedAt=c.CreatedAt,
                   UpdatedAt=c.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<UserViewModel> FindByUsernameAsync(string username)
        {
            return await _context.Users.AsNoTracking()
                 .Select(c => new UserViewModel
                 {
                     Username = c.Username,
                     Name = c.Name,
                     LastName = c.LastName,
                     Photo = c.Photo,
                     Email = c.Email,
                     IsActive = c.IsActive,
                     CreatedAt = c.CreatedAt,
                     UpdatedAt = c.UpdatedAt
                 })
                .FirstOrDefaultAsync(user => user.Username == username);
        }

    }
}
