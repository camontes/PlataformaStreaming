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

        Task<List<UserCourseViewModel>> FindAllByCourseIdAsync(int courseid);

        Task<List<UserCourseViewModel>> FindAllByUsernameAsync(string username);

        Task<UserCourseViewModel> FindByIdAsync(int id);

        Task<UserCourseViewModel> FindExistUserCourseAsync(string username, int courseid);

        Task<double> AverageCourseAsync(int courseid);
    }
}