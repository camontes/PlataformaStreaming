using SampleAPI.Domain.Models;
using SampleAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Infrastructure.Repositories
{
    public class StreamRepository : IStreamRepository
    {
        protected readonly ApplicationDbContext _context;

        public StreamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task UpdateSytreamAsync(Stream stream)
        {
            _context.Streams.Update(stream);
            await _context.SaveChangesAsync();
        }
    }
}
