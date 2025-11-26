
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
    private readonly IReservationService _reservationService;
    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpPost("book")]
    public async Task<IActionResult> BookTickets(BookTicketsDto dto)
    {
        await _reservationService.BookTickets(dto);
        return Ok($"Reserva exitosa");
    }

    [HttpPost("purchase")]
    public async Task<IActionResult> PurchaseTickets(PurchaseTicketsDto dto)
    {
        try
        {
            await _reservationService.PurchaseTickets(dto);
            return Ok($"Compra exitosa");
        }
        catch(TeatroTicketsException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}