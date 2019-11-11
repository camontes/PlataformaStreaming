using AutoMapper;
using SampleAPI.Commands;
using SampleAPI.Domain;
using SampleAPI.ViewModels;

namespace SampleAPI.Mappings
{
    public class CourseMappings : Profile
    {
        public CourseMappings()
        {
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<UpdateCourseCommand, Course>();
            CreateMap<Course, BasicCourseViewModel>();
        }
    }
}