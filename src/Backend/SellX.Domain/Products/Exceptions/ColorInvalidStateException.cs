namespace SellX.Domain.Products.Exceptions;
public class ColorInvalidStateException : ApplicationException
{
    public ColorInvalidStateException(string message) : base(message) { }
}