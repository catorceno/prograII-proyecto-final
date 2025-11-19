
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class PerformerController
{
    private readonly IPerformerService performerService;
    public PerformerController(IPerformerService performerService)
    {
        this.performerService = performerService;
    }

    [HttpPost("create-request")]
    public async Task CreateRequest(EventCreateDto eventDto)
    {
        await performerService.CreateRequest(eventDto);
    }
}