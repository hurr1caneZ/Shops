using Microsoft.Win32.SafeHandles;
using Shops.Entities;
using Shops.Exceptions;

namespace Shops.Models;

public class Order
{
    private readonly List<ProductAmountPair> _cart;
    public Order()
    {
        _cart = new List<ProductAmountPair>();
    }

    public IReadOnlyCollection<ProductAmountPair> Cart => _cart;
    public string ShopAddress { get; internal set; }

    public void AddProductToCart(string productInCart, uint amount, Shop shop)
    {
        if (shop is null && shop.Address != ShopAddress && !string.IsNullOrEmpty(ShopAddress))
            throw new AddProductFromAnotherShopException();
        ShopAddress = shop.Address;
        var productAmountPair = new ProductAmountPair(productInCart, amount);
        _cart.Add(productAmountPair);
    }

    public void RemoveProductFromCart(string productInCart, uint amount)
    {
        ProductAmountPair foundProd = _cart.Find(product => product.Name == productInCart);
        if (foundProd is not null)
        {
            if (foundProd.Amount - amount != 0)
            {
                throw new Exception("недостаточно товара");
            }
        }
        else
        {
            throw new NoSuchProductInTheCartException();
        }
    }

    public void Clear()
    {
        _cart.Clear();
    }

    // Order)
}