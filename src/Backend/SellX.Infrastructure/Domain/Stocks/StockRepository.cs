using Microsoft.EntityFrameworkCore;
using SellX.Domain.Products;
using SellX.Domain.Stocks;
using SellX.Infrastructure.Database;

namespace SellX.Infrastructure.Domain.Products;
public class StockRepository : IStockRepository
{
    private readonly IApplicationDbContext context;

    public StockRepository(IApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task Add(Stock stock)
    {
        _ = await context.Stocks.AddAsync(stock);
    }

    public void Remove(Stock stock)
    {
        _ = context.Stocks.Remove(stock);
    }

    public void Update(Stock stock)
    {
        _ = context.Stocks.Update(stock);
    }
}