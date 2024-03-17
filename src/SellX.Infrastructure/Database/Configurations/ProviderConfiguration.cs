using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SellX.Domain.SeedWork;
using SellX.Domain.Providers;

namespace SellX.Infrastructure.Database.Configurations;
internal class ProductConfigProviderConfigurationuration : IEntityTypeConfiguration<Provider>
{
    public void Configure(EntityTypeBuilder<Provider> builder)
    {
        _ = builder.ToTable("Providers", SchemaNames.SellX);

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(e => e.Id)
            .HasConversion(id => id.Value, value => new ProviderId(value));

        _ = builder.Property(e => e.TenantId)
            .HasConversion(id => id.Value, value => new TenantId(value));

        _ = builder.Property(p => p.Name).IsRequired();
    }
}