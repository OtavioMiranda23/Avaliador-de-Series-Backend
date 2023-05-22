using AutoMapper;
using WebApplication1.Data.Dtos;

namespace WebApplication1.Models.Profiles;

public class SerieProfile : Profile
{
    public SerieProfile()
    {
        CreateMap<CreateSerieDto, Serie>();
        CreateMap<UpdateSerieDto, Serie>();
        CreateMap<Serie, UpdateSerieDto>();
        CreateMap<Serie, ReadSerieDto>();
    }
}