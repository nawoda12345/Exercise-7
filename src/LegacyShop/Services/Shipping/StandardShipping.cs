using LegacyShop.Domain.Interfaces;

namespace LegacyShop.Services.Shipping
{
    public class StandardShipping : IShippingStrategy
    {
        public decimal CalculateShipping(decimal subtotal)
        {
            return 5.0m;
        }
    }
}
