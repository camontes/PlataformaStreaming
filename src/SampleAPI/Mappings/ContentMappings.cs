using AutoMapper;
using SampleAPI.Commands;
using SampleAPI.Domain;
using SampleAPI.Domain.Models;
using SampleAPI.ViewModels;

namespace SampleAPI.Mappings
{
    public class ContentMappings : Profile
    {
        public ContentMappings()
        {
            CreateMap<CreateContentCommand, Content>();
            CreateMap<UpdateContentCommand, Content>();
            CreateMap<Content, BasicContentViewModel>();
            CreateMap<ContentViewModel, Content>();
        }
    }
}