using AutoMapper;
using Receptdatabas.Repositories.Models.DTOs;
using Receptdatabas.Repositories.Models.Entities;
using System.IO.Compression;

namespace Receptdatabas.Repositories.Models.Profiles
{
    public class RecipeProfile:Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeDto>()
                .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.User));
            CreateMap<RecipeDto, Recipe>();
        }
        
    }
}
