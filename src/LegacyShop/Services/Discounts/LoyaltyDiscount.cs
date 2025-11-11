using LegacyShop.Domain.Interfaces;
using LegacyShop.Domain.Models;

namespace LegacyShop.Services.Discounts
{
    public class LoyaltyDiscount : IDiscountPolicy
    {
        public bool IsApplicable(Order order) => order.LoyaltyPoints >= 100;

        public decimal GetDiscount(Order order) => 10.0m;
    }
}
