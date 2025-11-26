
public class BookTicketsDto
{
    public int? CustomerId { get; set; }
    public int PerformanceId { get; set; }
    public List<int> PriceZoneSeatIds { get; set; }
}