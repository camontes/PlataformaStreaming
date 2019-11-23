using SampleAPI.Domain;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public interface IQuestionQueries
    {
        Task<List<QuestionViewModel>> FindAllAsync();

        Task<List<QuestionViewModel>> GetAllByCourseIdAsync(int CourseId);

        Task<QuestionViewModel> FindByIdAsync(int id);
    }
}
