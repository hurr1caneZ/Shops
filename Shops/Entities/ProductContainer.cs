using Shops.Models;

namespace Shops.Entities;

public class ProductContainer
{
    public ProductContainer(ProductInfo productInfo, Product product)
    {
        if (productInfo is null || product is null)
            throw new ArgumentException("Bad arguments");
        ProductInfo = productInfo;
        Product = product;
    }

    public ProductInfo ProductInfo { get; internal set; }
    public Product Product { get; internal set; }

    // ProductContainer)
}