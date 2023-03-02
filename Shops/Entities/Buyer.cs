using Shops.Models;

namespace Shops.Entities;

public class Buyer
{
    public Buyer(string name, decimal balance)
    {
        Name = name ?? throw new ArgumentException(nameof(name));
        Balance = balance;
        Wishlist = new Order();
    }

    public string Name { get; internal set; }
    public decimal Balance { get; internal set; }
    public Order Wishlist { get; internal set; }
    public void AddToOrder(string productInCart, uint amount, Shop shop)
    {
        if (productInCart is null || shop is null)
            throw new ArgumentException("Bad arguments");
        Wishlist.AddProductToCart(productInCart, amount, shop);
    }

    public decimal Buy(Shop shop)
    {
        decimal moneyToPay = shop.ProductSum(Wishlist.Cart);
        if (Balance >= moneyToPay)
        {
            Balance -= moneyToPay;
            foreach (var productInCart in Wishlist.Cart)
            {
                Wishlist.RemoveProductFromCart(productInCart.Name, productInCart.Amount);
            }

            return moneyToPay;
        }

        throw new ArgumentException("No money no honey");
    }

    public void ClearCart()
    {
        Wishlist.Clear();
    }

    // Buyer)
}