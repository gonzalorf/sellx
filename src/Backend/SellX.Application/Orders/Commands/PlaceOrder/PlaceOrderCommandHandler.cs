using SellX.Application.Configuration.Commands;
using SellX.Domain.Orders;
using SellX.Domain.Orders.Events;
using SellX.Domain.Products;

namespace SellX.Application.Orders.Commands.PlaceOrder;
internal class PlaceOrderCommandHandler : ICommandHandler<PlaceOrderCommand, OrderId>
{
    private readonly IOrderRepository orderRepository;

    public PlaceOrderCommandHandler(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }

    public async Task<OrderId> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Order.CreateOrder(DateOnly.FromDateTime(DateTime.Today)
            , request.Customer
            , request.CustomerEmail
            , request.CustomerTaxId);
        
        foreach (var detail in request.Details)
        {
            order.AddOrderDetail(new ProductId(detail.ProductId)
                , new SizeId(detail.SizeId)
                , detail.Count
                , detail.Price);
        }

        await orderRepository.Add(order);
        order.AddDomainEvent(new OrderPlacedEvent(order.Id));
        return order.Id;
    }
}