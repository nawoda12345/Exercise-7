using LegacyShop.Domain.Interfaces;

namespace LegacyShop.Services.Shipping
{
    public class ExpressShipping : IShippingStrategy
    {
        public decimal CalculateShipping(decimal subtotal)
        {
            return 15.0m;
        }
    }
}
