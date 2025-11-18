
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class SeatingPlanController
{
    private readonly ISeatingPlanService seatingPlanService;
    public SeatingPlanController(ISeatingPlanService seatingPlanService)
    {
        this.seatingPlanService = seatingPlanService;
    }

    [HttpGet("{id:int}/seating-plan")]
    public async Task<SeatingPlanDto> GetByTheaterId(int id)
    {
        var seatingPlanDto = await seatingPlanService.GetByTheaterId(id);
        return seatingPlanDto;
    }
}