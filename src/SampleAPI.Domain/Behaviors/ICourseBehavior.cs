using System.Collections.Generic;
using System.Threading.Tasks;


namespace SampleAPI.Domain.Managers
{
    public interface ICourseBehavior
    {
        Task CreateCourseAsync(Course course);
        Task DeleteCourseAsync(Course course);
        Task UpdateCourseAsync(Course course, string Photo);
        Task UpdateEnrolledStudentCourseAsync(Course course);
        Task UpdateIsStreamingCourseAsync(Course course, bool isStreaming);
        Task UpdateRatingCourseAsync(Course course, double averageCourse);
        Task UpdatePostCourseAsync(Course course);
    }
}

