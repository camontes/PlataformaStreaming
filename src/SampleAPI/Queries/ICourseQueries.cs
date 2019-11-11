using SampleAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public interface ICourseQueries
    {
        Task<List<Course>> FindAllAsync();

        Task<List<Course>> GetAllByCategoryIdAsync(int CategoryId);

        Task<Course> FindByIdAsync(int id);
    }
}
