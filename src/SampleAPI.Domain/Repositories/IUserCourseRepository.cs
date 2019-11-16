using SampleAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Repositories
{
    public interface IUserCourseRepository
    {
        Task CreateUserCourseAsync(UserCourse Usercourse);
        Task DeleteUserCourseAsync(UserCourse Usercourse);
        Task UpdateRatingUserCourseAsync(UserCourse Usercourse);
    }
}
