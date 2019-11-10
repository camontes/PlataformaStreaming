using SampleAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public interface ICategoryQueries
    {
        Task<List<Category>> FindAllAsync();
        Task<Category> FindByIdAsync(int id);
    }
}
