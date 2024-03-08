namespace SellX.Domain.Providers.Exceptions;
public class ProviderInvalidStateException : ApplicationException
{
    public ProviderInvalidStateException(string message) : base(message) { }
}