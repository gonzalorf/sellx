using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SellX.Infrastructure.Domain.Parameters;

namespace SellX.Infrastructure.Database.Configurations;
internal class ParameterConfiguration : IEntityTypeConfiguration<Parameter>
{
    public void Configure(EntityTypeBuilder<Parameter> builder)
    {
        _ = builder.ToTable("Parameters", SchemaNames.SellX);

        _ = builder.HasKey(x => x.Name);
    }
}
