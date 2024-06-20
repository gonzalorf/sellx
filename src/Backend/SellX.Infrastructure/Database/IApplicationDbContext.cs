using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using SellX.Domain.Orders;
using SellX.Domain.Products;
using SellX.Domain.Providers;
using SellX.Domain.Stocks;
using SellX.Domain.Tenants;
using SellX.Domain.Users;

namespace SellX.Infrastructure.Database;
public interface IApplicationDbContext
{

    DbSet<User> Users { get; set; }
    DbSet<Tenant> Tenants { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Provider> Providers { get; set; }
    DbSet<Stock> Stocks { get; set; }
    DbSet<Order> Orders { get; set; }
    IDataParameter CreateParameter(string name, object value);
    DbConnection Connection { get; }
}
