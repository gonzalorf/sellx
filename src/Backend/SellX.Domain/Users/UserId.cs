using SellX.Domain.SeedWork;

namespace SellX.Domain.Users;
public record UserId(Guid Value) : TypedIdValueBase(Value);
