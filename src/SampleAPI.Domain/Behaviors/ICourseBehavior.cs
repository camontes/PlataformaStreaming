using System.Collections.Generic;
using System.Threading.Tasks;


namespace SampleAPI.Domain.Managers
{
    public interface ICourseBehavior
    {
        Task CreateCourseAsync(Course course);
        Task DeleteCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
    }
}

