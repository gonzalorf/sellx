using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SellX.Domain.Orders;
using SellX.Domain.Products;
using SellX.Domain.SeedWork;

namespace SellX.Infrastructure.Database.Configurations;
internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        _ = builder.ToTable("OrderDetails", SchemaNames.SellX);
        
        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(e => e.Id)
            .HasConversion(id => id.Value, value => new OrderDetailId(value));

        _ = builder.Property(e => e.TenantId)
            .HasConversion(id => id.Value, value => new TenantId(value));

        _ = builder.Property(e => e.ProductId)
            .HasConversion(id => id.Value, value => new ProductId(value));

        _ = builder.Property(e => e.SizeId)
            .HasConversion(id => id.Value, value => new SizeId(value));
    }
}
