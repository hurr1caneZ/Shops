namespace Shops.Exceptions;

public class IncorrectProductNameException : Exception
{
    public IncorrectProductNameException(string productName)
            : base($"ProductName can't be {productName}")
        { }
}