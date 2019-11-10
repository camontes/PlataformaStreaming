using AutoMapper;
using SampleAPI.Commands;
using SampleAPI.Domain;
using SampleAPI.ViewModels;

namespace SampleAPI.Mappings
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
            CreateMap<Category, BasicCategoryViewModel>();

        }
    }
}
