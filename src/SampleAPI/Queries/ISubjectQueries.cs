using SampleAPI.Domain;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public interface ISubjectQueries
    {
        Task<List<SubjectViewModel>> FindAllAsync();

        Task<List<SubjectViewModel>> GetAllByCourseIdAsync(int courseId);

        Task<SubjectViewModel> FindByIdAsync(int id);
    }
}
