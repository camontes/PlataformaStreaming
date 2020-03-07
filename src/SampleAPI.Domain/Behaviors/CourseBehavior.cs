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
            course.PostedAt = null;
            course.Rating = 0;
            course.IsPublished = false;
            await _repository.CreateCourseAsync(course);
        }

        public async Task UpdateCourseAsync(Course course, string Photo)
        {
            if (course is null) throw new ArgumentNullException(nameof(course));

            if (course.Photo == "")
            {
                course.Photo = Photo;
            }
            course.UpdatedAt = DateTime.Now;
            await _repository.UpdateCourseAsync(course);
        }

        public async Task UpdatePostCourseAsync(Course course)
        {
            if (course is null) throw new ArgumentNullException(nameof(course));

            course.IsPublished = true;
            course.PostedAt = DateTime.Now;
            await _repository.UpdatePostCourseAsync(course);
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

