using AutoMapper;
using SampleAPI.Commands;
using SampleAPI.Domain.Models;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Mappings
{
    public class UserContentMappings : Profile
    {
        public UserContentMappings()
        {
            CreateMap<CreateUserContentCommand, UserContent>();
            CreateMap<UserContent, BasicUserContentViewModel>();
            CreateMap<BasicUserContentViewModel, UserContent>();
        }
    }
}
