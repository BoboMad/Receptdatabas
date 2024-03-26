using Receptdatabas.Repositories.Models.DTOs;
using Receptdatabas.Repositories.Models.Entities;
using AutoMapper;

namespace Receptdatabas.Repositories.Models.Profiles
{
    public class RatingProfile:Profile
    {
        public RatingProfile()
        {
            CreateMap<Rating, RatingDto>();
            CreateMap<RatingDto, Rating>();
        }
    }
}
