using LegacyShop.Domain.Interfaces;
using LegacyShop.Domain.Models;

namespace LegacyShop.Services.Discounts
{
    public class BookDiscount : IDiscountPolicy
    {
        public bool IsApplicable(Order order) =>
            order.Items.Any(i => i.Category.Equals("Book", StringComparison.OrdinalIgnoreCase));

        public decimal GetDiscount(Order order) =>
            order.Subtotal * 0.05m;
    }
}
