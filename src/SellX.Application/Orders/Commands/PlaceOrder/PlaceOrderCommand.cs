using SellX.Application.Configuration.Commands;
using SellX.Domain.Orders;
using SellX.Domain.Products;

namespace SellX.Application.Orders.Commands.PlaceOrder;
public record PlaceOrderCommand(
    ProductId ProductId
    , SizeId SizeId
    , int Count
    , string Customer
    , string CustomerEmail
    , decimal Price
    ) : CommandBase<OrderId>;