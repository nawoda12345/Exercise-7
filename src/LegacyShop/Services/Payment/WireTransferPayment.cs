using LegacyShop.Domain.Interfaces;

namespace LegacyShop.Services.Payment
{
    public class WireTransferPayment : IPaymentStrategy
    {
        public decimal CalculatePaymentFee(decimal subtotal) => 0m;
    }
}
