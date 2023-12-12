namespace SellX.Infrastructure.Outbox;

public interface IIntegrationEventsDispatcher
{
    Task DispatchEventsAsync();
}