using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SellX.Application.Usuarios.Services;
using SellX.Domain.SeedWork;

namespace SellX.Infrastructure.Database.Interceptors;
public class MultiTenancyInterceptor : SaveChangesInterceptor
{
    private readonly ICurrentUserService _currentUserService;

    public MultiTenancyInterceptor(
        ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context)
    {
        if (context == null)
        {
            return;
        }

        foreach (var entry in context.ChangeTracker.Entries<IEntity>())
        {
            if (entry.State == EntityState.Added
                && _currentUserService?.TenantId is not null)
            {
                entry.Entity.TenantId = _currentUserService?.TenantId;

                foreach (var e in entry.Entity.DomainEvents)
                {
                    e.TenantId = _currentUserService?.TenantId;
                }
            }
        }
    }
}
