using SellX.Domain.Products;
using SellX.Domain.Providers;
using SellX.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace SellX.Infrastructure.Domain.Products;
public class ProductRepository : IProductRepository
{
    private readonly IApplicationDbContext context;

    public ProductRepository(IApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task Add(Product product)
    {
        _ = await context.Products.AddAsync(product);
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await context.Products
        .Include(p => p.Sizes)
        .Include(p => p.Provider)
        .ToListAsync();
    }

    public async Task<Product?> GetById(ProductId id)
    {
        return await context.Products.SingleAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetByProviderId(ProviderId providerId)
    {
        return await context.Products.Where(p => p.ProviderId == providerId) .ToListAsync();
    }

    public void Remove(Product product)
    {
        _ = context.Products.Remove(product);
    }

    public void Update(Product product)
    {
        _ = context.Products.Update(product);
    }
}