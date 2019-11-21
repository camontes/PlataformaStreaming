using SampleAPI.Domain.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Managers
{
    public class CourseBehavior : ICourseBehavior
    {
        protected readonly ICourseRepository _repository;

        public CourseBehavior(ICourseRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateCourseAsync(Course course)
        {
            if (course is null) throw new ArgumentNullException(nameof(course));

            course.IsActive = true;
            course.CreatedAt = DateTime.Now;
            course.UpdatedAt = DateTime.Now;
            course.Rating = 0;
            await _repository.CreateCourseAsync(course);
        }

        public async Task UpdateCourseAsync(Course course)
        {
            if (course is null) throw new ArgumentNullException(nameof(course));

            course.UpdatedAt = DateTime.Now;
            await _repository.UpdateCourseAsync(course);
        }

        public async Task UpdateRatingCourseAsync(Course course, double averageCourse)
        {
            if (course is null) throw new ArgumentNullException(nameof(course));

            course.UpdatedAt = DateTime.Now;
            course.Rating = averageCourse;
            await _repository.UpdateCourseAsync(course);
        }

        public async Task DeleteCourseAsync(Course course)
        {
            if (course is null) throw new ArgumentNullException(nameof(course));

            await _repository.DeleteCourseAsync(course);
        }
    }
}

