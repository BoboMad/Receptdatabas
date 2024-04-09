using AutoMapper;
using Receptdatabas.Repositories.Models.DTOs;
using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Repositories.Models.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Recipes, opt => opt.Ignore());
            CreateMap<CategoryDto, Category>();
        }
    }
}
