using LegacyShop.Domain.Interfaces;

namespace LegacyShop.Services.Shipping
{
    public class ShippingStrategyFactory
    {
        private readonly Dictionary<string, IShippingStrategy> _strategies;

        public ShippingStrategyFactory(IEnumerable<IShippingStrategy> strategies)
        {
            _strategies = strategies.ToDictionary(s => s.GetType().Name.Replace("Shipping", ""), StringComparer.OrdinalIgnoreCase);
        }

        public IShippingStrategy GetStrategy(string method)
        {
            if (!_strategies.TryGetValue(method, out var strategy))
                throw new ArgumentException($"Unknown shipping method: {method}");

            return strategy;
        }
    }
}
