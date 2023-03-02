using Shops.Entities;
using Shops.Models;

namespace Shops.Services;

public class ShopManager : IShopManager
{
    private List<Buyer> _buyersList;
    private List<Shop> _shopsList;

    public ShopManager()
    {
        _buyersList = new List<Buyer>();
        _shopsList = new List<Shop>();
    }

    public Product AddProduct(Product product, ProductInfo productInfo, Shop shop)
    {
        var newProduct = new ProductContainer(new ProductInfo(productInfo.Amount, productInfo.Price), product);
        shop.RegistrationProduct(product.Name, productInfo.Amount, productInfo.Price);
        return newProduct.Product;
    }

    public Shop AddShop(string name, string address)
    {
        var newShop = new Shop(name, address);
        _shopsList.Add(newShop);
        return newShop;
    }

    public Buyer AddBuyer(string name, decimal balance)
    {
        var newBuyer = new Buyer(name, balance);
        _buyersList.Add(newBuyer);
        return newBuyer;
    }

    public Buyer GetBuyer(string name)
    {
        return _buyersList.Find(buyer => buyer.Name == name) ?? throw new Exception();
    }

    public Shop FindShopWithLowestPrice(Product product)
    {
        if (product is null)
            throw new ArgumentNullException("Incorrect arguments");

        decimal curMin = decimal.MaxValue;
        Shop minShop = null;
        var shopsHaveProduct = _shopsList.Where(shop => shop.ContainsProduct(product.Name)).ToList();
        foreach (Shop shop in shopsHaveProduct)
        {
            decimal price = shop.FindProduct(product.Name).ProductInfo.Price;
            if (price < curMin)
            {
                curMin = price;
                minShop = shop;
            }
        }

        return minShop;
    }

    public void ChangeProductPrice(Product product, Shop shop, decimal newPrice)
    {
        if (product is null || shop is null)
            throw new ArgumentNullException("Bad arguments");
        shop.FindProduct(product.Name).ProductInfo.Price = newPrice;
    }

    public void AddProductToWishlist(Buyer buyer, Shop shop, Product product, uint amount)
    {
        if (buyer is null || shop is null || product is null)
            throw new ArgumentNullException("Bad arguments");
        buyer.AddToOrder(product.Name, amount, shop);
    }

    public void BuyingProcess(Buyer buyer, Shop shop)
    {
        if (buyer is null || shop is null)
            throw new ArgumentException("Bad Arguments");
        buyer.Buy(shop);
        shop.RemoveOrderProducts(buyer.Wishlist.Cart);
        buyer.ClearCart();
    }

    // ShopManager
}