using SampleAPI.Domain;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public interface ICourseQueries
    {
        Task<List<CourseViewModel>> FindAllAsync();

        Task<List<CourseViewModel>> GetAllByCategoryIdAsync(int CategoryId);

        Task<List<CourseViewModel>> GetAllByUsernameAsync(string username);

        Task<CourseViewModel> FindByIdAsync(int id);
    }
}
