
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PerformanceController : ControllerBase
{
    private readonly IPerformanceService _performanceService;
    public PerformanceController(IPerformanceService performanceService)
    {
        _performanceService = performanceService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePerformance([FromBody] PerformanceCreateDto performanceDto)
    {
        var newPerformanceId = await _performanceService.Create(performanceDto);
        return Ok($"yes: {newPerformanceId}");
    }

    [HttpGet]
    public async Task<List<PerformanceDto>> GetAllByPlayId(int playId)
    {
        return await _performanceService.GetAllByPlayId(playId);
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<PerformanceDto>> GetById(int id)
    {
        var performance =  await _performanceService.GetById(id);
        if(performance == null) return NotFound("no existe performance");
        return performance;
    }

    [HttpGet("seating-plan")]
    public async Task<PerformanceSeatingPlanDto> GetSeatingPlanByPerformanceId(int performanceId)
    {
        return await _performanceService.GetSeatingPlanByPerformanceId(performanceId);
    }

}