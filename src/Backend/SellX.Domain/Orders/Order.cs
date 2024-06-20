using SellX.Domain.Orders.Events;
using SellX.Domain.Products;
using SellX.Domain.SeedWork;

namespace SellX.Domain.Orders;

public class Order : AuditableEntity<OrderId>, IAggregateRoot
{
    public DateOnly Date { get; private set;}
    public string Customer { get; private set; }
    public string CustomerEmail { get; private set; }
    public string CustomerTaxId { get; private set; }


    private readonly List<OrderDetail> orderDetails = new();
    public IReadOnlyCollection<OrderDetail> OrderDetails => orderDetails.AsReadOnly();

    private Order(){}

    private Order(OrderId id, DateOnly date, string customer, string customerEmail, string customerTaxId) : base(id)
    {
        Date = date;
        Customer = customer;
        CustomerEmail = customerEmail;
        CustomerTaxId = customerTaxId;
    }

    public static Order CreateOrder(DateOnly date, string customer, string customerEmail, string customerTaxId)
    {
        var order = new Order(new OrderId(Guid.NewGuid()), date, customer, customerEmail, customerTaxId);
        OrderValidator.ValidateOrder(order);
        order.AddDomainEvent(new OrderPlacedEvent(order.Id));

        return order;
    }

    public OrderDetail AddOrderDetail(
        ProductId productId
        , SizeId sizeId
        , int count
        , decimal price)
    {
        var orderDetail = OrderDetail.CreateOrderDetail(productId, sizeId, count, price);
        orderDetails.Add(orderDetail);

        return orderDetail;
    }
}
