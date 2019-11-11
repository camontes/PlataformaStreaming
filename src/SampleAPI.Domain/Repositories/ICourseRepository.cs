using System.Collections.Generic;
using System.Threading.Tasks;


namespace SampleAPI.Domain.Infrastructure.Repositories
{
    public interface ICourseRepository
    {
        Task CreateCourseAsync(Course course);
        Task DeleteCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
    }
}