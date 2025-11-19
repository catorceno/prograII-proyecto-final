
using AutoMapper;
using backend.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserInfoDto>();

        CreateMap<Row, RowDto>()
            .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats));

        CreateMap<Seat, SeatDto>()
            .ForMember(dest => dest.Side, opt => opt.MapFrom(src =>
                string.Equals(src.Side, "L", StringComparison.OrdinalIgnoreCase) ? Side.L : Side.R));

        CreateMap<Event, EventCreateDto>();
        CreateMap<Play, PlayCreateDto>();
        CreateMap<Performance, PerformanceCreateDto>();
    }
}