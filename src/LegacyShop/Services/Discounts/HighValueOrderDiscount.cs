using LegacyShop.Domain.Interfaces;
using LegacyShop.Domain.Models;

namespace LegacyShop.Services.Discounts
{
    public class HighValueOrderDiscount : IDiscountPolicy
    {
        public bool IsApplicable(Order order) =>
            order.Subtotal > 100;

        public decimal GetDiscount(Order order) => 10m;
    }
}
