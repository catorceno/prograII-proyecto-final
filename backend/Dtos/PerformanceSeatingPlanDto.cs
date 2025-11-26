
public class PerformanceSeatingPlanDto
{
    public List<PriceZoneDto> PriceZoneDtos { get; set; }
}

public class PriceZoneDto
{
    public int PriceZoneId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public List<RowDto> RowDtos { get; set; }
}
public class RowDto
{
    public int RowId { get; set; }
    public string Name { get; set; }
    public List<PriceZoneSeatDto> PriceZoneSeatsDto { get; set; }
}
public class PriceZoneSeatDto
{
    public int PriceZoneSeatId { get; set; }
    public PriceZoneSeatState State { get; set; }
    public int Column { get; set; }
    public int Number { get; set; }
    public SeatSide Side { get; set; }
}