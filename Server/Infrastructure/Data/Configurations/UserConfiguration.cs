using EslOnline.Domain.Aggregates;
using EslOnline.SharedKernel.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EslOnline.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(o => o.Id).HasConversion(o => o.Value, value => new UserId(value));
        builder.Property(o => o.CitizenId).HasConversion(o => o.Value, value => new CitizenId(value));
        builder.HasIndex(o => o.GMail).IsUnique();
        builder.Property(o => o.GMail)
               .HasMaxLength(256)
               .IsRequired();
    }
}