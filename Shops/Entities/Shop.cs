using Shops.Exceptions;
using Shops.Models;

namespace Shops.Entities;

public class Shop
{
    private List<ProductContainer> _productContainers;

    public Shop(string name, string address)
    {
        if (name is null || address is null)
            throw new ArgumentException(nameof(name));
        Address = address;
        Name = name;
        _productContainers = new List<ProductContainer>();
    }

    public IReadOnlyCollection<ProductContainer> ProductsList { get => _productContainers; }
    public string Address { get; internal set; }
    public string Name { get; internal set; }

    public uint FindAmountOfProduct(string name)
    {
        return FindProduct(name).ProductInfo.Amount;
    }

    public decimal FindProductPrice(string name)
    {
        return FindProduct(name).ProductInfo.Price;
    }

    public bool ContainsProduct(string name)
    {
        return FindProduct(name) is not null && FindProduct(name).ProductInfo.Amount > 0;
    }

    internal void RegistrationProduct(string productName, uint amount, decimal price)
    {
        if (FindProduct(productName) is not null)
            throw new IncorrectProductNameException(productName);
        _productContainers.Add(new ProductContainer(new ProductInfo(amount, price), new Product(productName)));
    }

    internal void DecProductInShop(string productName, uint amount)
    {
        var foundProduct = FindProduct(productName);
        if (foundProduct is null)
            throw new ArgumentNullException(nameof(productName));
        foundProduct.ProductInfo.Amount -= amount;
    }

    internal ProductContainer FindProduct(string productName)
    {
        return _productContainers.Find(product => product.Product.Name == productName);
    }

    internal decimal ProductSum(IReadOnlyCollection<ProductAmountPair> productContainerList)
    {
        decimal sum = 0;
        foreach (var findProduct in productContainerList)
        {
            sum += FindProductPrice(findProduct.Name) * findProduct.Amount;
        }

        return sum;
    }

    internal void RemoveOrderProducts(IReadOnlyCollection<ProductAmountPair> wishlistCart)
    {
        if (wishlistCart is not null)
        {
            foreach (ProductAmountPair productAmountPair in wishlistCart)
            {
                DecProductInShop(productAmountPair.Name, productAmountPair.Amount);
            }
        }
    }

    // Shop)
}