using EslOnline.Domain.Aggregates.Buildings;
using EslOnline.SharedKernel.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EslOnline.Infrastructure.Data.Configurations;

public class HomeConfiguration : IEntityTypeConfiguration<Home>
{
    public void Configure(EntityTypeBuilder<Home> builder)
    {
        builder.Property(o => o.Id).HasConversion(o => o.Value, value => new HomeId(value));
        builder.Property(o => o.LocationId).HasConversion(o => o.Value, value => new CityId(value));
    }
}
