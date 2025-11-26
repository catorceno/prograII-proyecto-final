
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PlayController : ControllerBase
{
    private readonly IPlayService _playService;
    public PlayController(IPlayService playService)
    {
        _playService = playService;
    }
    [HttpPost]
    public async Task<IActionResult> CreatePlay([FromBody] PlayCreateDto playDto)
    {
        int newPlayId = await _playService.Create(playDto);
        return Ok($"yes: {newPlayId}");
    }

    [HttpGet]
    public async Task<List<PlayDto>> GetAllPublished()
    {
        var plays = await _playService.GetAllPublished();
        return plays;
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<PlayDetailsDto>> GetPublishedById(int id)
    {
        var play = await _playService.GetPublishedById(id);

        if(play == null) return NotFound("no existe play");
        return play;
    }
}
/*
not found
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.5",
  "title": "Not Found",
  "status": 404,
  "traceId": "00-b69c30abc4fee57c9b9f684d1f8e9578-461ba5932dbe5d09-00"
}
*/