using LegacyShop.Domain.Interfaces;

namespace LegacyShop.Services.Payment
{
    public class PaymentStrategyFactory
    {
        private readonly Dictionary<string, IPaymentStrategy> _strategies;

        public PaymentStrategyFactory(IEnumerable<IPaymentStrategy> strategies)
        {
            _strategies = new Dictionary<string, IPaymentStrategy>(StringComparer.OrdinalIgnoreCase)
         {
           { "CreditCard", strategies.First(s => s is CreditCardPayment) },
           { "PayPal", strategies.First(s => s is PaypalPayment) },
           { "Wire", strategies.First(s => s is WireTransferPayment) }
    };
        }

        public IPaymentStrategy GetStrategy(string method)
        {
            if (!_strategies.TryGetValue(method, out var strategy))
                throw new ArgumentException($"Unknown payment method: {method}");

            return strategy;
        }
    }
}
