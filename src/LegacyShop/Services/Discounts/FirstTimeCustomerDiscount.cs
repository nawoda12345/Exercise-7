using LegacyShop.Domain.Interfaces;
using LegacyShop.Domain.Models;

namespace LegacyShop.Services.Discounts
{
    public class FirstTimeCustomerDiscount : IDiscountPolicy
    {
        public bool IsApplicable(Order order) => order.IsFirstTimeCustomer;

        public decimal GetDiscount(Order order) => 5.0m;
    }
}
