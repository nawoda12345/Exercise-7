namespace LegacyShop.Domain.Interfaces
{
    public interface IShippingStrategy
    {
        decimal CalculateShipping(decimal subtotal);
    }
}
