using AutoMapper;
using SampleAPI.Commands;
using SampleAPI.Domain;
using SampleAPI.Domain.Models;
using SampleAPI.ViewModels;

namespace SampleAPI.Mappings
{
    public class UserCourseMappings : Profile
    {
        public UserCourseMappings()
        {
            CreateMap<CreateUserCourseCommand, UserCourse>();
            CreateMap<UpdateUserCourseCommand, UserCourse>();
            CreateMap<UserCourse, BasicUserCourseViewModel>();
            CreateMap<UserCourseViewModel, UserCourse>();
        }
    }
}
