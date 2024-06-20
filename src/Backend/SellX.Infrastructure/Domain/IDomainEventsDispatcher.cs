namespace SellX.Infrastructure.Domain;

public interface IDomainEventsDispatcher
{
    Task DispatchEventsAsync();
}