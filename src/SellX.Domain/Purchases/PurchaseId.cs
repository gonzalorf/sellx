using SellX.Domain.SeedWork;

namespace SellX.Domain.Purchases;

public record PurchaseId(Guid Value) : TypedIdValueBase(Value);