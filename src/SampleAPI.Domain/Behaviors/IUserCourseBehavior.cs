using SampleAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Behaviors
{
    public interface IUserCourseBehavior
    {
        Task CreateUserCourseAsync(UserCourse userCourse);
        Task DeleteUserCourseAsync(UserCourse userCourse);
        Task UpdateRatingUserCourseAsync(UserCourse userCourse);

        Task UpdateCorrectAnswersCourseAsync(UserCourse userCourse, int correctAnswers);

        Task UpdateProgressUserCourseAsync(UserCourse userCourse, int countUserContents, int countContents);
    }
}