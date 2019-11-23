using AutoMapper;
using SampleAPI.Commands;
using SampleAPI.Domain;
using SampleAPI.Domain.Models;
using SampleAPI.ViewModels;

namespace SampleAPI.Mappings
{
    public class QuestionMappings : Profile
    {
        public QuestionMappings()
        {
            CreateMap<CreateQuestionCommand, Question>();
            CreateMap<UpdateQuestionCommand, Question>();
            CreateMap<Question, BasicQuestionViewModel>();
            CreateMap<QuestionViewModel, Question>();
        }
    }
}
