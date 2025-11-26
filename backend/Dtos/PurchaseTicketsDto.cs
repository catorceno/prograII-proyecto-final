
public class PurchaseTicketsDto : BookTicketsDto
{
    public decimal Amount { get; set; }
    public PaymentMethod Method { get; set; }
}