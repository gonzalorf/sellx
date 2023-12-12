using Microsoft.EntityFrameworkCore;
using SellX.Infrastructure.Database;

namespace SellX.Infrastructure.Outbox;
public class OutboxMessageRepository : IOutboxMessageRepository
{
    private readonly ApplicationDbContext context;

    public OutboxMessageRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task Add(OutboxMessage outboxMessage)
    {
        _ = await context.Set<OutboxMessage>().AddAsync(outboxMessage);
    }

    public async Task<IList<OutboxMessage>> GetUnprocessed(int count)
    {
        return await context.Set<OutboxMessage>().Where(m => m.ProcessedDate == null).Take(count).ToListAsync();
    }
}
