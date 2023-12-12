using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SellX.Domain.Products;
using SellX.Domain.SeedWork;

namespace SellX.Infrastructure.Database.Configurations;
internal class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        _ = builder.ToTable("Sizes", SchemaNames.SellX);

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(e => e.Id)
            .HasConversion(id => id.Value, value => new SizeId(value));

        _ = builder.Property(e => e.TenantId)
            .HasConversion(id => id.Value, value => new TenantId(value));

        _ = builder.Property(t => t.Price).HasColumnType("money");
        _ = builder.Property(t => t.PreviousPrice).HasColumnType("money");
    }
}