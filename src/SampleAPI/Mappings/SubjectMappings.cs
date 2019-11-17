using AutoMapper;
using SampleAPI.Commands;
using SampleAPI.Domain;
using SampleAPI.Domain.Models;
using SampleAPI.ViewModels;

namespace SampleAPI.Mappings
{
    public class SubjectMappings : Profile
    {
        public SubjectMappings()
        {
            CreateMap<CreateSubjectCommand, Subject>();
            CreateMap<UpdateSubjectCommand, Subject>();
            CreateMap<Subject, BasicSubjectViewModel>();
            CreateMap<SubjectViewModel, Subject>();
        }
    }
}