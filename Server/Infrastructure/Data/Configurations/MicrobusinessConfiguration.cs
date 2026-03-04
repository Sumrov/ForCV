using EslOnline.Domain.Aggregates.Buildings;
using EslOnline.SharedKernel.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EslOnline.Infrastructure.Data.Configurations;

public class MicrobusinessConfiguration : IEntityTypeConfiguration<Microbusiness>
{
    public void Configure(EntityTypeBuilder<Microbusiness> builder)
    {
        builder.Property(o => o.Id).HasConversion(o => o.Value, value => new MicrobusinessId(value));
        builder.Property(o => o.LocationId).HasConversion(o => o.Value, value => new CityId(value));
        builder.Property(o => o.OwnerId).HasConversion(o => o.Value, value => new CitizenId(value));
    }
}