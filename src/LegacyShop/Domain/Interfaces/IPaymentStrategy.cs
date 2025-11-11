namespace LegacyShop.Domain.Interfaces
{
    public interface IPaymentStrategy
    {
        decimal CalculatePaymentFee(decimal subtotal);
    }
}
