using EslOnline.Domain.Aggregates.Subjects;
using EslOnline.SharedKernel.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EslOnline.Infrastructure.Data.Configurations;

public class GovernmentConfiguration : IEntityTypeConfiguration<Government>
{
    public void Configure(EntityTypeBuilder<Government> builder)
    {
        builder.Property(o => o.Id).HasConversion(o => o.Value, value => new GovernmentId(value));
        builder.Property(o => o.LocationId).HasConversion(o => o.Value, value => new CityId(value));
        builder.Property(o => o.HeadGovernmentId).HasConversion(
                o => o.HasValue ? o.Value.Value : (Guid?)null,
                o => o.HasValue ? new GovernmentId(o.Value) : null)
            .IsRequired(false);
        builder.OwnsOne(o => o.Codex, o =>
        {
            o.Property(o => o.Id).HasConversion(o => o.Value, o => new CodexId(o));
        });

        builder.OwnsOne(o => o.Currency, o =>
        {
            o.Property(o => o.Id).HasConversion(o => o.Value, o => new CurrencyId(o));
        });
    }
}