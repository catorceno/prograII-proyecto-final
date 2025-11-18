
using AutoMapper;
using backend.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserInfoDto>();

        // Map Row -> RowDto including its Seats
        CreateMap<Row, RowDto>()
            .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats));

        // Map Seat -> SeatDto and convert side string to enum
        CreateMap<Seat, SeatDto>()
            .ForMember(dest => dest.Side, opt => opt.MapFrom(src =>
                string.Equals(src.Side, "L", StringComparison.OrdinalIgnoreCase) ? Side.L : Side.R));
    }
}