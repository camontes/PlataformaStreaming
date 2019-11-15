using SampleAPI.Domain;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public interface IUserCourseQueries
    {
        Task<List<UserCourseViewModel>> FindAllAsync();

        // Task<List<UserCourseViewModel>> GetAllByCourseIdAsync(int CourseId);

        // Task<List<UserCourseViewModel>> GetAllByUserIdAsync(int UserId);

        Task<UserCourseViewModel> FindByIdAsync(int id);
    }
}