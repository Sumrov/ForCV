using EslOnline.Domain.Aggregates.Buildings;
using EslOnline.SharedKernel.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EslOnline.Infrastructure.Data.Configurations;

public class TawnhallConfiguration : IEntityTypeConfiguration<Tawnhall>
{
    public void Configure(EntityTypeBuilder<Tawnhall> builder)
    {
        builder.Property(o => o.Id).HasConversion(o => o.Value, value => new TawnhallId(value));
        builder.Property(o => o.LocationId).HasConversion(o => o.Value, value => new CityId(value));
    }
}
