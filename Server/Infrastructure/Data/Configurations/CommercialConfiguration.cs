using EslOnline.Domain.Aggregates.Buildings;
using EslOnline.SharedKernel.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EslOnline.Infrastructure.Data.Configurations;

public class CommercialConfiguration : IEntityTypeConfiguration<Commercial>
{
    public void Configure(EntityTypeBuilder<Commercial> builder)
    {
        builder.Property(o => o.Id).HasConversion(o => o.Value, value => new CommercialId(value));
        builder.Property(o => o.LocationId).HasConversion(o => o.Value, value => new CityId(value));
    }
}