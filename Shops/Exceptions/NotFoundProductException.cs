namespace Shops.Exceptions;

public class NotFoundProductException : Exception
{
    public NotFoundProductException()
        : base($"Product is not found")
    { }
}