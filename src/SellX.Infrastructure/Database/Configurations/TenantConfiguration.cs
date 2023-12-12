using SellX.Domain.SeedWork;
using SellX.Domain.Tenants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SellX.Infrastructure.Database.Configurations;
internal class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        _ = builder.ToTable("Tenants", SchemaNames.SellX);

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(e => e.Id)
                    .HasConversion(id => id.Value, value => new TenantId(value));


    }
}
