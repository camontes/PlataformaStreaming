using SampleAPI.Domain;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public interface IOptionQueries
    {
        Task<List<OptionViewModel>> FindAllAsync();

        Task<List<OptionViewModel>> GetAllByQuestionIdAsync(int QuestionId);

        Task<List<OptionViewModel>> GetAllByCourseIdAsync(int CourseId);

        Task<OptionViewModel> FindByIdAsync(int id);
    }
}
