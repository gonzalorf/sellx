namespace SellX.Application.Common.Exceptions;
public class InvalidQueryFiltersException : ApplicationException
{
    public InvalidQueryFiltersException(string message) : base(message) { }
}
