using Newtonsoft.Json;
using SellX.Application.Usuarios.Services;
using SellX.Domain.SeedWork;
using SellX.Infrastructure.Database;

namespace SellX.Infrastructure.Outbox;
public class IntegrationEventsDispatcher : IIntegrationEventsDispatcher
{
    private readonly ApplicationDbContext context;
    private readonly IOutboxMessageRepository outboxRepository;
    private readonly ICurrentUserService currentUserService;

    public IntegrationEventsDispatcher(ApplicationDbContext context, IOutboxMessageRepository outboxRepository, ICurrentUserService currentUserService)
    {
        this.context = context;
        this.outboxRepository = outboxRepository;
        this.currentUserService = currentUserService;
    }

    public async Task DispatchEventsAsync()
    {
        var domainEntities = context.ChangeTracker.Entries<IEntity>()
            .Where(x => x.Entity.IntegrationEvents is not null && x.Entity.IntegrationEvents.Any()).ToList();


        domainEntities.ForEach(e => e.Entity.IntegrationEvents.ToList()
            .ForEach(i => i.TenantId ??= currentUserService.TenantId));

        domainEntities.ForEach(e => e.Entity.ClearIntegrationEvents());

        var integrationEvents = domainEntities
            .SelectMany(x => x.Entity.IntegrationEvents)
            .ToList();

        foreach (var integrationEvent in integrationEvents)
        {
            var type = integrationEvent.GetType().FullName;
            var data = JsonConvert.SerializeObject(integrationEvent, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });

            var outboxMessage = new OutboxMessage(
                currentUserService.TenantId,
                currentUserService.UserId?.Value,
                integrationEvent.OccurredOn,
                type!,
                data);
            await outboxRepository.Add(outboxMessage);
        }

    }
}