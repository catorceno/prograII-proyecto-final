
public class PriceZoneCreateDto
{
    public int PlayId { get; set; }
    public string Name { get; set; }
    public decimal PricePresale { get; set; }
    public decimal Price { get; set; }
    public int FromSeatId { get; set; }
    public int ToSeatId { get; set; }
}

