
public class PaymentAmountTooLowException : TeatroTicketsException
{
    public PaymentAmountTooLowException(decimal amount, decimal total)
        : base($"El monto del pago ({amount}) es menor al total ({total}).")
    {
    }
}
