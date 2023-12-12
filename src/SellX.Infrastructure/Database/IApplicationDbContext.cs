using Microsoft.EntityFrameworkCore;
using SellX.Domain.Products;
using SellX.Domain.Stocks;
using SellX.Domain.Tenants;
using SellX.Domain.Users;

namespace SellX.Infrastructure.Database;
public interface IApplicationDbContext
{

    DbSet<User> Users { get; set; }
    DbSet<Tenant> Tenants { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Stock> Stocks { get; set; }
}
