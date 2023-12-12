using MediatR;
using SellX.Application.Usuarios.Services;
using SellX.Domain.SeedWork;
using SellX.Infrastructure.Database;

namespace SellX.Infrastructure.Domain;
public class DomainEventsDispatcher : IDomainEventsDispatcher
{
    private readonly ApplicationDbContext context;
    private readonly ICurrentUserService currentUserService;
    private readonly IMediator mediator;

    public DomainEventsDispatcher(ApplicationDbContext context, ICurrentUserService currentUserService, IMediator mediator)
    {
        this.context = context;
        this.currentUserService = currentUserService;
        this.mediator = mediator;
    }

    public async Task DispatchEventsAsync()
    {
        var domainEntities = context.ChangeTracker.Entries<IEntity>()
            .Where(x => x.Entity.DomainEvents is not null && x.Entity.DomainEvents.Any()).ToList();

        domainEntities.ForEach(e => e.Entity.DomainEvents.ToList()
            .ForEach(i => i.TenantId ??= currentUserService.TenantId));

        domainEntities.ForEach(e => e.Entity.ClearDomainEvents());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEvents.ForEach(async e => await mediator.Publish(e));

    }
}