using SellX.Application.Usuarios.Services;
using SellX.Domain.SeedWork;
using SellX.Domain.Users;
using System.Security.Claims;

namespace SellX.API.Services;
public class CurrentUserService : ICurrentUserService
{
    private TenantId? overriddenTenantId = null;
    private UserId? overriddenUserId = null;
    private string? overriddenUserType = null;

    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    TenantId? ICurrentUserService.TenantId => overriddenTenantId is not null
                ? overriddenTenantId
                : _httpContextAccessor.HttpContext is null
                    || _httpContextAccessor.HttpContext.User is null
                    || _httpContextAccessor.HttpContext.User.Identity is null
                    ? null
                    : _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated
                        ? new(Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue("TenantId")))
                        : null;
    UserId? ICurrentUserService.UserId => overriddenUserId is not null
                ? overriddenUserId
                : _httpContextAccessor.HttpContext is null
                || _httpContextAccessor.HttpContext.User is null
                || _httpContextAccessor.HttpContext.User.Identity is null
                ? null
                : _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated
                ? new(Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier)))
                : null;


    public void OverrideTenantId(TenantId? tenantId)
    {
        overriddenTenantId = tenantId;
    }

    public void OverrideUserId(UserId? userId)
    {
        overriddenUserId = userId;
    }
}
