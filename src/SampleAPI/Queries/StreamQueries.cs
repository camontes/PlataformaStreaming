using Microsoft.EntityFrameworkCore;
using SampleAPI.Infrastructure;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public class StreamQueries : IStreamQueries
    {
        protected readonly ApplicationDbContext _context;

        public StreamQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StreamViewModel> GetStream()
        {
            return await _context.Streams.AsNoTracking()
                .Select(s => new StreamViewModel
                {
                    Id = s.Id,
                    Url = s.Url
                })
                .FirstOrDefaultAsync();
        }
    }
}
