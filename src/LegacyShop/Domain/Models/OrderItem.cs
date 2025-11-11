namespace LegacyShop.Domain.Models
{
    public class OrderItem
    {
        public string Sku { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
