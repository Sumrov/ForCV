using EslOnline.Domain.Aggregates.Buildings;
using EslOnline.SharedKernel.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EslOnline.Infrastructure.Data.Configurations;

public class IndustrialConfiguration : IEntityTypeConfiguration<Industrial>
{
    public void Configure(EntityTypeBuilder<Industrial> builder)
    {
        builder.Property(o => o.Id).HasConversion(o => o.Value, value => new IndustrialId(value));
        builder.Property(o => o.LocationId).HasConversion(o => o.Value, value => new CityId(value));
    }
}
