using SellX.Domain.SeedWork;

namespace SellX.Domain.Orders;
public record OrderDetailId(Guid Value) : TypedIdValueBase(Value);