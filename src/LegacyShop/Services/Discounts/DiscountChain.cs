using LegacyShop.Domain.Interfaces;
using LegacyShop.Domain.Models;

namespace LegacyShop.Services.Discounts
{
    public class DiscountChain
    {
        private readonly List<IDiscountPolicy> _policies;

        public DiscountChain(IEnumerable<IDiscountPolicy> policies)
        {
            _policies = policies.ToList();
        }

        public decimal CalculateDiscount(Order order)
        {
            foreach (var policy in _policies)
            {
                if (policy.IsApplicable(order))
                    return policy.GetDiscount(order);
            }

            return 0;
        }
    }
}
