using System.Collections.Generic;

namespace LegacyShop.Domain.Models
{
    public class Order
    {
        public List<OrderItem> Items { get; set; } = new();

        public decimal Subtotal { get; set; }
        public string ShippingMethod { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public bool IsFirstTimeCustomer { get; set; }
        public int LoyaltyPoints { get; set; }

        // These are populated during processing
        public decimal Discount { get; set; }
        public decimal Shipping { get; set; }
        public decimal PaymentFee { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }
}
