using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SellX.Domain.Products;
using SellX.Domain.SeedWork;
using SellX.Infrastructure.Database.Converters;

namespace SellX.Infrastructure.Database.Configurations;
internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        _ = builder.ToTable("Products", SchemaNames.SellX);

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(e => e.Id)
            .HasConversion(id => id.Value, value => new ProductId(value));

        _ = builder.Property(e => e.TenantId)
            .HasConversion(id => id.Value, value => new TenantId(value));

        _ = builder.Property(p => p.Name).IsRequired().HasMaxLength(256);
        _ = builder.Property(p => p.Description).IsRequired();
        _ = builder.Property(p => p.Price).IsRequired();

        _ = builder.Property(p => p.Tags)
            .IsRequired()
            .HasConversion<StringListToStringConverter>();
    }
}