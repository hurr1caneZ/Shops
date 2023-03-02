using Shops.Entities;

namespace Shops.Models;

public class ProductInfo
{
    public ProductInfo(uint amount, decimal price)
    {
        Amount = amount;
        Price = price;
    }

    public uint Amount { get; internal set; }
    public decimal Price { get; internal set; }

    // ProductInfo)
}