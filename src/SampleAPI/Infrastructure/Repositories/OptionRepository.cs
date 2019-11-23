using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleAPI.Domain.Infrastructure.Repositories;
using SampleAPI.Domain;
using SampleAPI.Domain.Models;

namespace SampleAPI.Infrastructure.Repositories
{
    public class OptionRepository : IOptionRepository
    {
        protected readonly ApplicationDbContext _context;

        public OptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateOptionAsync(Option option)
        {
            _context.Options.Add(option);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOptionAsync(Option option)
        {
            _context.Options.Update(option);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOptionAsync(Option option)
        {
            _context.Options.Remove(option);
            await _context.SaveChangesAsync();
        }
    }
}
