using Application.Casts.Queries.GetCast;
using AutoMapper;
using Domain.Entities.Casts;

namespace Application.MapperConfiguration;

/// <summary>
/// Represent an auto mapper profile
/// </summary>
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Cast, GetCastCastDto>().ForMember(dest => dest.Age,
                opt => opt.MapFrom(src => src.Age.Value))
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName.Value))
            .ForMember(dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName.Value));
    }
}
