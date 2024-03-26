using Receptdatabas.Repositories.Models.DTOs;
using Receptdatabas.Repositories.Models.Entities;
using AutoMapper;

namespace Receptdatabas.Repositories.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
