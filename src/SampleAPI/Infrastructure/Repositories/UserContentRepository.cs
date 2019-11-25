using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleAPI.Domain.Infrastructure.Repositories;
using SampleAPI.Domain;
using SampleAPI.Domain.Models;

namespace SampleAPI.Infrastructure.Repositories
{
    public class UserContentRepository : IUserContentRepository
    {
        protected readonly ApplicationDbContext _context;

        public UserContentRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task CreateUserContentAsync(UserContent usercontent)
        {
            _context.UserContents.Add(usercontent);
            await _context.SaveChangesAsync();
        }
    }
}

