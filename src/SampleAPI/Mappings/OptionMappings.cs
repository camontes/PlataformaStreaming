using AutoMapper;
using SampleAPI.Commands;
using SampleAPI.Domain;
using SampleAPI.Domain.Models;
using SampleAPI.ViewModels;

namespace SampleAPI.Mappings
{
    public class OptionMappings : Profile
    {
        public OptionMappings()
        {
            CreateMap<CreateOptionCommand, Option>();
            CreateMap<UpdateOptionCommand, Option>();
            CreateMap<Option, BasicOptionViewModel>();
            CreateMap<OptionViewModel, Option>();
        }
    }
}