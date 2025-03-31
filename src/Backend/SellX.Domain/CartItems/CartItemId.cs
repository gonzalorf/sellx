using SellX.Domain.SeedWork;

namespace SellX.Domain.CartItems;
public record CartItemId(Guid Value) : TypedIdValueBase(Value);