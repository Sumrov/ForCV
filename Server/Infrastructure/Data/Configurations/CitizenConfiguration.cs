using EslOnline.Domain.Aggregates.Subjects;
using EslOnline.SharedKernel.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EslOnline.Infrastructure.Data.Configurations;

public class CitizenConfiguration : IEntityTypeConfiguration<Citizen>
{
    public void Configure(EntityTypeBuilder<Citizen> builder)
    {
        builder.Property(o => o.Id).HasConversion(o => o.Value, value => new CitizenId(value));
        builder.Property(o => o.BornId).HasConversion(o => o.Value, value => new CityId(value));
        builder.Property(o => o.CitizenshipId).HasConversion(o => o.Value, value => new GovernmentId(value));
        builder.OwnsOne(o => o.Location, o =>
        {
            o.Property(o => o.BuildingId).HasConversion(o => o.Value, o => new BuildingId(o));
            o.Property(o => o.CityId).HasConversion(o => o.Value, o => new CityId(o));
            o.Property(o => o.TargetBuildingId).HasConversion(
                o => o.HasValue ? o.Value.Value : (Guid?)null,
                o => o.HasValue ? new BuildingId(o.Value) : null)
            .IsRequired(false);
            o.Property(o => o.VehicleId).HasConversion(
                o => o.HasValue ? o.Value.Value : (Guid?)null,
                o => o.HasValue ? new VehicleId(o.Value) : null)
            .IsRequired(false);
            o.Property(o => o.PublicVehicleId).HasConversion(
                o => o.HasValue ? o.Value.Value : (Guid?)null,
                o => o.HasValue ? new VehicleId(o.Value) : null)
            .IsRequired(false);
        });

        builder.OwnsOne(o => o.Job, o =>
        {
            o.Property(o => o.SubjectId).HasConversion(o => o.Value, o => new SubjectId(o));
        });
    }
}