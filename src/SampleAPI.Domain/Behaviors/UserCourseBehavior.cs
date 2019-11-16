using SampleAPI.Domain.Models;
using SampleAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Behaviors
{
    public class UserCourseBehavior : IUserCourseBehavior
    {
        protected readonly IUserCourseRepository _repository;

        public UserCourseBehavior(IUserCourseRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateUserCourseAsync(UserCourse userCourse)
        {
            if (userCourse is null) throw new ArgumentNullException(nameof(userCourse));

            userCourse.CreatedAt = DateTime.Now;
            userCourse.UpdatedAt = DateTime.Now;
            userCourse.IsEnd = false;
            userCourse.Rating = 0;

            await _repository.CreateUserCourseAsync(userCourse);
        }

        public async Task UpdateRatingUserCourseAsync(UserCourse userCourse)
        {
            if (userCourse is null) throw new ArgumentNullException(nameof(userCourse));

            userCourse.UpdatedAt = DateTime.Now;

            await _repository.UpdateRatingUserCourseAsync(userCourse);
        }

        public async Task DeleteUserCourseAsync(UserCourse userCourse)
        {
            if (userCourse is null) throw new ArgumentNullException(nameof(userCourse));

            await _repository.DeleteUserCourseAsync(userCourse);
        }
    }
}