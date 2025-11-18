
public class SeatingPlanDto
{
    public int TheaterId { get; set; }
    public List<RowDto> Rows { get; set; }
}
public class RowDto
{
    public string Name { get; set; }
    public List<SeatDto> Seats { get; set; }
}
public class SeatDto
{
    public int Column { get; set; }
    public int Number { get; set; }
    public Side Side { get; set; }
}

public enum Side
{
    L,
    R
}