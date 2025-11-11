// using LegacyShop.Domain.Models;
// using LegacyShop.Services.Discounts;
// using LegacyShop.Services.Payment;
// using LegacyShop.Services.Shipping;

// namespace LegacyShop.OrderProcessing
// {
//     public class OrderProcessor
//     {
//         private readonly ShippingStrategyFactory _shippingFactory;
//         private readonly PaymentStrategyFactory _paymentFactory;
//         private readonly DiscountChain _discountChain;

//         public OrderProcessor(
//             ShippingStrategyFactory shippingFactory,
//             PaymentStrategyFactory paymentFactory,
//             DiscountChain discountChain)
//         {
//             _shippingFactory = shippingFactory;
//             _paymentFactory = paymentFactory;
//             _discountChain = discountChain;
//         }

//         public decimal CalculateTotal(Order order)
//         {
//             var shippingStrategy = _shippingFactory.GetStrategy(order.ShippingMethod);
//             var paymentStrategy = _paymentFactory.GetStrategy(order.PaymentMethod);

//             var shipping = shippingStrategy.CalculateShipping(order.Subtotal);
//             var discount = _discountChain.CalculateDiscount(order);

//             var taxableAmount = order.Subtotal - discount + shipping;
//             var tax = taxableAmount * 0.10m;

//             var paymentFee = paymentStrategy.CalculatePaymentFee(order.Subtotal);

//             return taxableAmount + tax + paymentFee;
//         }
//     }
// }

using System.Linq;
using LegacyShop.Domain.Models;
using LegacyShop.Services.Discounts;
using LegacyShop.Services.Payment;
using LegacyShop.Services.Shipping;
using LegacyShop.Domain.Interfaces;

namespace LegacyShop.OrderProcessing
{
    public class OrderProcessor
    {
        private readonly ShippingStrategyFactory _shippingFactory;
        private readonly PaymentStrategyFactory _paymentFactory;
        private readonly DiscountChain _discountChain;

        public OrderProcessor()
        {
            _shippingFactory = new ShippingStrategyFactory(new IShippingStrategy[]
            {
                new StandardShipping(),
                new ExpressShipping()
            });

            _paymentFactory = new PaymentStrategyFactory(new IPaymentStrategy[]
            {
                new CreditCardPayment(),
                new PaypalPayment(),
                new WireTransferPayment()
            });

            _discountChain = new DiscountChain(new IDiscountPolicy[]
            {
                new BookDiscount(),
                new HighValueOrderDiscount()
            });
        }

        public void Process(Order order)
        {
            // 1. Subtotal: sum of all order items
            order.Subtotal = order.Items.Sum(i => i.UnitPrice * i.Quantity);

            // 2. Discount (first-match from chain)
            order.Discount = _discountChain.CalculateDiscount(order);

            // 3. Shipping
            order.Shipping = _shippingFactory
                .GetStrategy(order.ShippingMethod)
                .CalculateShipping(order.Subtotal);

            // 4. Payment fee (calculated on subtotal)
            order.PaymentFee = _paymentFactory
                .GetStrategy(order.PaymentMethod)
                .CalculatePaymentFee(order.Subtotal);

            // 5. Tax: 10% of (subtotal - discount + shipping), excluding payment fee
            var taxBase = order.Subtotal - order.Discount + order.Shipping;
            order.Tax = taxBase * 0.10m;

            // 6. Final total
            order.Total = order.Subtotal - order.Discount + order.Shipping + order.PaymentFee + order.Tax;
        }
    }
}
