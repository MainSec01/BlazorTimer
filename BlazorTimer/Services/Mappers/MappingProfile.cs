using AutoMapper;
using BlazorTimer.Modals;
using BlazorTimer.Services.DTOs;

namespace BlazorTimer.Services.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TimerInfo, TimerInfoForCreation>().ReverseMap();
    }
}
