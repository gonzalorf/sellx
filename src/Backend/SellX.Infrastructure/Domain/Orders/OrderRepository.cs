using SellX.Domain.Orders;
using SellX.Domain.Products;
using SellX.Infrastructure.Database;

namespace SellX.Infrastructure.Domain.Orders;
public class OrderRepository : IOrderRepository
{
    private readonly IApplicationDbContext context;

    public OrderRepository(IApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task Add(Order order)
    {
        _ = await context.Orders.AddAsync(order);
    }

    public async Task<Order[]> GetByDates(DateOnly from, DateOnly to)
    {
        throw new NotImplementedException();
    }

    public async Task<Order?> GetById(OrderId id)
    {
        throw new NotImplementedException();
    }
}
