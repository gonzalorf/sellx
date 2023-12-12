using SellX.Domain.Users;

namespace SellX.Application.Configuration.Services;
public interface IJwtProvider
{
    string GetJwt(User user);
}
