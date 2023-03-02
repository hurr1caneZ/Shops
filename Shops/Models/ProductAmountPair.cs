using Shops.Entities;

namespace Shops.Models;

public class ProductAmountPair
{
    public ProductAmountPair(string name, uint amount)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException(nameof(name));
        Amount = amount;
        Name = name;
    }

    public uint Amount { get; internal set; }
    public string Name { get; internal set; }

    // ProductAmountPair)
}