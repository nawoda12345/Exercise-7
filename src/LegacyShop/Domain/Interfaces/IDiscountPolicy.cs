using LegacyShop.Domain.Models;

namespace LegacyShop.Domain.Interfaces
{
    public interface IDiscountPolicy
    {
        bool IsApplicable(Order order);
        decimal GetDiscount(Order order);
    }
}
