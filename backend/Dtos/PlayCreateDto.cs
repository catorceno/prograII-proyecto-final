
public class PlayCreateDto
{
    public int PerformerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string PlaybillPdf { get; set; }
    public int Duration { get; set; }
    public PlayCategory Category { get; set; }
    public DateTime DateStartPresale { get; set; }
    public DateTime DateStartOnsale { get; set; }
}