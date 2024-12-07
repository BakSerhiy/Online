using AutoMapper;
using Online.ReviewAndRating.Application.DTOs;
using ReviewAndRating.Domain.Entities;

namespace Online.ReviewAndRating.Application.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Review, ReviewDTO>().ReverseMap();
    }
}