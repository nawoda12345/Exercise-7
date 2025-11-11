using LegacyShop.Domain.Interfaces;

namespace LegacyShop.Services.Payment
{
    public class PaypalPayment : IPaymentStrategy
    {
        public decimal CalculatePaymentFee(decimal subtotal)
        {
            return subtotal * 0.03m;
        }
    }
}
