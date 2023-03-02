namespace Shops.Exceptions;

public class AddProductFromAnotherShopException : Exception
{
    public AddProductFromAnotherShopException()
        : base($"Try adding product from another shop")
    { }
}