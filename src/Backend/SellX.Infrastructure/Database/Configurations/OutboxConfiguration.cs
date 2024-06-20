using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SellX.Domain.SeedWork;
using SellX.Infrastructure.Outbox;

namespace SellX.Infrastructure.Database.Configurations;
internal class OutboxConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        _ = builder.ToTable("OutboxMessages", SchemaNames.SellX);

        _ = builder.HasKey(b => b.Id);

        _ = builder.Property(e => e.TenantId)
                    .HasConversion(id => id.Value, value => new TenantId(value));

        _ = builder.Property(e => e.Data).HasColumnType("nvarchar(max)");
    }
}
