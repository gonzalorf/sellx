namespace SellX.Infrastructure.Outbox;
public interface IOutboxMessageRepository
{
    Task Add(OutboxMessage outboxMessage);

    Task<IList<OutboxMessage>> GetUnprocessed(int count);
}
