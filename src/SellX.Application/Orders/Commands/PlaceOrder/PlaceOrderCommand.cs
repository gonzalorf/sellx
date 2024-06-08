using SellX.Application.Configuration.Commands;
using SellX.Domain.Orders;
using SellX.Domain.Products;

namespace SellX.Application.Orders.Commands.PlaceOrder;
public record PlaceOrderCommand(
    string Customer
    , string CustomerEmail
    , string CustomerTaxId
    , PlaceOrderCommandDetail[] Details
    ) : CommandBase<OrderId>;

public record PlaceOrderCommandDetail(
    Guid ProductId
    , Guid SizeId
    , int Count
    , decimal Price
    );