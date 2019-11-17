using SampleAPI.Domain;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public interface IContentQueries
    {
        Task<List<ContentViewModel>> FindAllAsync();

        // Task<List<CourseViewModel>> GetAllBySubjectIdAsync(int CategoryId);

        Task<ContentViewModel> FindByIdAsync(int id);
    }
}