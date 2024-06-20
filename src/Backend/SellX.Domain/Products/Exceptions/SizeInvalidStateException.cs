namespace SellX.Domain.Products.Exceptions;
public class SizeInvalidStateException : ApplicationException
{
    public SizeInvalidStateException(string message) : base(message) { }
}