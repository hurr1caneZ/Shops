namespace Shops.Exceptions;

public class NoSuchProductInTheCartException : Exception
{
    public NoSuchProductInTheCartException()
        : base("There is no such product in the cart")
    { }
}