namespace Shops.Entities;

public class Product
{
    public Product(string productName)
    {
        if (productName is null)
            throw new ArgumentException(nameof(productName));
        Name = productName;
    }

    public string Name { get; set; }

    // Product)
}