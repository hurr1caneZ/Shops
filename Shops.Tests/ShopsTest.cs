using Shops.Entities;
using Shops.Models;
using Shops.Services;
using Xunit;

namespace Shops.Test;

public class ShopsTest
{
    private ShopManager shopManager = new ShopManager();
    [Fact]
    public void AddProductsToShop()
    {
        var shop = shopManager.AddShop("diksi", "street");
        var product = shopManager.AddProduct(new Product("kolbasa"), new ProductInfo(100, 200), shop);
        Assert.True(shop.ContainsProduct(product.Name));
    }

    [Fact]
    public void BuyingProcessCheck()
    {
        var shop = shopManager.AddShop("diksi", "street");
        var product = shopManager.AddProduct(new Product("kolbasa"), new ProductInfo(100, 200), shop);
        var buyer = shopManager.AddBuyer("shoev", 33333);
        shopManager.AddProductToWishlist(buyer, shop, product, 1);
        shopManager.BuyingProcess(buyer, shop);
        Assert.Equal(99U, shop.FindAmountOfProduct(product.Name));
        Assert.Equal(33133, buyer.Balance);
    }

    [Fact]
    public void ChangePriceCheck()
    {
        var shop = shopManager.AddShop("diksi", "street");
        var product = shopManager.AddProduct(new Product("kolbasa"), new ProductInfo(100, 200), shop);
        shopManager.ChangeProductPrice(product, shop, 123);
        Assert.Equal(123, shop.FindProductPrice(product.Name));
    }

    [Fact]
    public void FindMinShop()
    {
        var shop1 = shopManager.AddShop("pyaterochka", "address");
        var shop2 = shopManager.AddShop("magnit", "mars");
        var shop3 = shopManager.AddShop("tinkoff", "usa");
        var findProd1 = shopManager.AddProduct(new Product("arbuz"), new ProductInfo(123, 3), shop1);
        var findProd2 = shopManager.AddProduct(new Product("arbuz"), new ProductInfo(123, 21), shop2);
        var findProd3 = shopManager.AddProduct(new Product("arbuz"), new ProductInfo(123, 15), shop3);
        var shop = shopManager.FindShopWithLowestPrice(findProd1);
        Assert.Equal(shop, shop1);
    }

    // ShopsTest)
}