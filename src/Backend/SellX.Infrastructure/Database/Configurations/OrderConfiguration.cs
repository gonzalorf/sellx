﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SellX.Domain.Orders;
using SellX.Domain.SeedWork;
using SellX.Infrastructure.Database.Converters;

namespace SellX.Infrastructure.Database.Configurations;
internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        _ = builder.ToTable("Orders", SchemaNames.SellX);

        _ = builder.HasKey(x => x.Id);

        _ = builder.Property(e => e.Id)
            .HasConversion(id => id.Value, value => new OrderId(value));

        _ = builder.Property(e => e.TenantId)
            .HasConversion(id => id.Value, value => new TenantId(value));

        _ = builder.Property(e => e.Date)
            .HasConversion<DateOnlyConverter>();
    }
}