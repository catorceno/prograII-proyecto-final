
public class EventCreateDto
{
    public int TheaterId { get; set; }
    public int PerformerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string PlaybillPdf { get; set; }
    public Category Category { get; set; }
    public TypeEvent Type { get; set; }
    public string State { get; set; }
    public List<PlayCreateDto> Plays { get; set; }
}
public class PlayCreateDto
{
    public int PerformerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public List<PerformanceCreateDto> Performances { get; set; }
}
public class PerformanceCreateDto
{
    public DateTime Datetime { get; set; }
    public StatePerformance State { get; set; }
}

public enum Category
{
    music,
    dance,
    theatre
}
public enum TypeEvent
{
    festival,
    show
}
public enum StatePerformance
{
    presale,
    onsale,
    soldout,
    completed,
    canceled
}