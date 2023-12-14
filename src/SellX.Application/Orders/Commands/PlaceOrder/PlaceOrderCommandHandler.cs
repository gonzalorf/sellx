using SellX.Application.Configuration.Commands;
using SellX.Domain.Orders;
using SellX.Domain.Orders.Events;

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
            , request.ProductId
            , request.SizeId
            , request.Count
            , request.Customer
            , request.CustomerEmail
            , request.Price);
        
        await orderRepository.Add(order);
        order.AddDomainEvent(new OrderPlacedEvent(order.Id));
        return order.Id;
    }
}