using SellX.Domain.SeedWork;

namespace SellX.Domain.Orders;
public record OrderItemId(Guid Value) : TypedIdValueBase(Value);