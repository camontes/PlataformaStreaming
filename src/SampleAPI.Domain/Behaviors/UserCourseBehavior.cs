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
            userCourse.CorrectAnswers = 0;
            userCourse.Rating = 0;
            userCourse.Progress = 0;

            await _repository.CreateUserCourseAsync(userCourse);
        }

        public async Task UpdateRatingUserCourseAsync(UserCourse userCourse)
        {
            if (userCourse is null) throw new ArgumentNullException(nameof(userCourse));

            userCourse.UpdatedAt = DateTime.Now;

            await _repository.UpdateRatingUserCourseAsync(userCourse);
        }

        public async Task UpdateCorrectAnswersCourseAsync(UserCourse userCourse, int correctAnswers)
        {
            if (userCourse is null) throw new ArgumentNullException(nameof(userCourse));

            userCourse.CorrectAnswers = correctAnswers;

            await _repository.UpdateRatingUserCourseAsync(userCourse);
        }

        public async Task UpdateProgressUserCourseAsync(UserCourse userCourse, int countUserContents, int countContents)
        {
            if (userCourse is null) throw new ArgumentNullException(nameof(userCourse));

            double progressDecimal = (double)((double)countUserContents / (double)countContents) * 100.00;
            var progress = Math.Ceiling(progressDecimal);

            if (progress == 100)
            {
                userCourse.IsEnd = true;
            }
            userCourse.Progress = (int)progress;
            userCourse.UpdatedAt = DateTime.Now;

            await _repository.UpdateProgressUserCourseAsync(userCourse);
        }

        public async Task DeleteUserCourseAsync(UserCourse userCourse)
        {
            if (userCourse is null) throw new ArgumentNullException(nameof(userCourse));

            await _repository.DeleteUserCourseAsync(userCourse);
        }
    }
}