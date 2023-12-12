using SellX.Application.Common.Services;
using SellX.Application.Usuarios.Services;
using SellX.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SellX.Infrastructure.Database.Interceptors;
public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTimeService _dateTime;

    public AuditableEntitySaveChangesInterceptor(
        ICurrentUserService currentUserService,
        IDateTimeService dateTime)
    {
        _currentUserService = currentUserService;
        _dateTime = dateTime;
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

    public void UpdateEntities(DbContext? context)
    {
        if (context == null)
        {
            return;
        }

        foreach (var entry in context.ChangeTracker.Entries<IAuditableEntity>())
        {
            var now = _dateTime.Now;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = _currentUserService?.UserId?.Value.ToString();
                entry.Entity.CreatedAt = now;
            }

            if (entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
            {
                entry.Entity.UpdatedBy = _currentUserService?.UserId?.Value.ToString();
                entry.Entity.UpdatedAt = now;
            }

            if (entry.State == EntityState.Deleted)
            {
                entry.Entity.DeletedBy = _currentUserService?.UserId?.Value.ToString();
                entry.Entity.DeletedAt = now;
            }
        }
    }
}

internal static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry)
    {
        return entry.References.Any(r =>
            r.TargetEntry != null &&
            r.TargetEntry.Metadata.IsOwned() &&
            (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
    }
}
