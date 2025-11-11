using LegacyShop.Domain.Interfaces;

namespace LegacyShop.Services.Payment
{
    public class CreditCardPayment : IPaymentStrategy
    {
        public decimal CalculatePaymentFee(decimal subtotal)
        {
            return subtotal * 0.02m;
        }
    }
}
