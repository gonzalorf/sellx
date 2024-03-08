using SellX.Domain.SeedWork;

namespace SellX.Domain.Providers;

public record ProviderId(Guid Value) : TypedIdValueBase(Value);