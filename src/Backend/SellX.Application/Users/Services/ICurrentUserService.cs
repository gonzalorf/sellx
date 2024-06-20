using SellX.Domain.SeedWork;
using SellX.Domain.Users;

namespace SellX.Application.Usuarios.Services;
public interface ICurrentUserService
{
    UserId? UserId { get; }
    TenantId? TenantId { get; }

    void OverrideTenantId(TenantId? tenantId);
    void OverrideUserId(UserId? userId);
}
