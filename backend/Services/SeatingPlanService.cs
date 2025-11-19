
using backend.Entities;

public class SeatingPlanService : ISeatingPlanService
{
    /*
    private readonly IUnitOfWork unitOfWork;
    public SeatingPlanService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    */
    private readonly ISeatingPlanRepository seatingPlanRepository;
    public SeatingPlanService(ISeatingPlanRepository seatingPlanRepository)
    {
        this.seatingPlanRepository = seatingPlanRepository;
    }
    public async Task<SeatingPlanDto> GetByTheaterId(int id)
    {
        var rows = await seatingPlanRepository.GetRowWithSeatByTheaterId(id);
        var seatingPlanDto = new SeatingPlanDto
        {
            TheaterId = id,
            Rows = rows.Select(r => new RowDto
            {
                Name = r.Name,
                Seats = r.Seats.Select(s => new SeatDto
                {
                    Column = s.Column,
                    Number = s.Number,
                    Side = s.Side == "L" ? Side.L : Side.R
                }).ToList()
            }).ToList()
        };

        return seatingPlanDto;
    }

    public async Task GetByPerformanceId(int id)
    {
    }
}

/*
using backend.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

public class SeatingPlanService : ISeatingPlanService
{
    private readonly TeatroTickets7Context context;
    private readonly IMapper mapper;
    public SeatingPlanService(TeatroTickets7Context context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<SeatingPlanDto> GetByTheaterId(int id)
    {
        var rows = await context.Rows
            .Where(r => r.TheaterId == id)
            .Include(r => r.Seats)
            .OrderBy(r => r.Name)
            .ToListAsync();

        var rowDtos = mapper.Map<List<RowDto>>(rows);

        var dto = new SeatingPlanDto
        {
            TheaterId = id,
            Rows = rowDtos
        };

        return dto;
    }
}
*/