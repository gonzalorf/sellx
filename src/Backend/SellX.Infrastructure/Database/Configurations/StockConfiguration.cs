using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SellX.Domain.SeedWork;
using SellX.Domain.Stocks;
using SellX.Domain.Products;

namespace SellX.Infrastructure.Database.Configurations;
internal class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        _ = builder.ToTable("Stocks", SchemaNames.SellX);

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(e => e.Id)
            .HasConversion(id => id.Value, value => new StockId(value));

        _ = builder.Property(e => e.ProductId)
            .HasConversion(id => id.Value, value => new ProductId(value));

        _ = builder.Property(e => e.SizeId)
            .HasConversion(id => id.Value, value => new SizeId(value));

        _ = builder.Property(e => e.TenantId)
            .HasConversion(id => id.Value, value => new TenantId(value));
    }
}