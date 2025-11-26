
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PriceZoneController : ControllerBase
{
    private readonly IPriceZoneService _priceZoneService;
    public PriceZoneController(IPriceZoneService priceZoneService)
    {
        _priceZoneService = priceZoneService;
    }
    [HttpPost]
    public async Task<IActionResult> CreateForPlay([FromBody] PriceZoneCreateDto priceZoneDto)
    {
        await _priceZoneService.CreateByPlayId(priceZoneDto);
        return Ok($"yes");
    }
}