using SellX.Domain.SeedWork;

namespace SellX.Domain.Orders;
public record OrderId(Guid Value) : TypedIdValueBase(Value);