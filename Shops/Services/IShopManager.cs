using Shops.Entities;
using Shops.Models;
namespace Shops.Services;

public interface IShopManager
{
    Product AddProduct(Product product, ProductInfo productInfo, Shop shop);
    Shop AddShop(string name, string address);
    Buyer GetBuyer(string name);
    Buyer AddBuyer(string name, decimal balance);
    void ChangeProductPrice(Product product, Shop shop, decimal newPrice);
    void AddProductToWishlist(Buyer buyer, Shop shop, Product product, uint amount);
    void BuyingProcess(Buyer buyer, Shop shop);

    // IShopManager)
}