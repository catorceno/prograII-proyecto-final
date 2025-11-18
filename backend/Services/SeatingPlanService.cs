
using backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;

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