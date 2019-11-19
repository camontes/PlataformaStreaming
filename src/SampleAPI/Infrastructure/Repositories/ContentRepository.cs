using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleAPI.Domain.Infrastructure.Repositories;
using SampleAPI.Domain;
using SampleAPI.Domain.Models;

namespace SampleAPI.Infrastructure.Repositories
{
    public class ContentRepository : IContentRepository
    {
        protected readonly ApplicationDbContext _context;

        public ContentRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task CreateContentAsync(Content content)
        {
            _context.Contents.Add(content);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContentAsync(Content content)
        {
            _context.Contents.Update(content);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContentAsync(Content content)
        {
            _context.Contents.Remove(content);
            await _context.SaveChangesAsync();
        }
    }
}
