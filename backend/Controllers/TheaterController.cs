
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TheaterController : ControllerBase
{
    private readonly ITheaterService _theaterService;
    public TheaterController(ITheaterService theaterService)
    {
        _theaterService = theaterService;
    }
    
    [HttpPut("cartelera/{playId}/reject")]
    public async Task<IActionResult> RejectRequest(int playId)
    {
        var success = await _theaterService.RejectRequest(playId);
        return Ok($"yes: {success}");
    }

    [HttpPut("cartelera/{playId}/accept")]
    public async Task<IActionResult> AcceptRequest(int playId)
    {
        var success = await _theaterService.AcceptRequest(playId);
        return Ok($"yes: {success}");
    }
    /*
    [HttpPut("cartelera/{playId}/cancel")]
    public async Task<IActionResult> CancelPlay(int playId)
    {
        var success = await _theaterService.CancelPlay(playId);
        return Ok($"yes: {success}");
    }

    [HttpPut("play/{performanceId}/cancel")]
    public async Task<IActionResult> CancelPerformance(int playId)
    {
        var success = await _theaterService.CancelPerformance(playId);
        return Ok($"yes: {success}");
    }
    */
}