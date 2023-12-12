using Microsoft.EntityFrameworkCore;
using SellX.Domain.Products;
using SellX.Infrastructure.Database;

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

    public async Task<Product?> GetById(ProductId id)
    {
        return await context.Products.FirstOrDefaultAsync(p => p.Id == id);
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