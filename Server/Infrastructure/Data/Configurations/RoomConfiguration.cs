using EslOnline.Domain.Aggregates.Goods;
using EslOnline.SharedKernel.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EslOnline.Infrastructure.Data.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.Property(o => o.Id).HasConversion(o => o.Value, value => new RoomId(value));
        builder.Property(o => o.LocationId).HasConversion(o => o.Value, value => new BuildingId(value));
        builder.Property(o => o.OwnerId).HasConversion(o => o.Value, value => new SubjectId(value));
        builder.Property(o => o.ProductId).HasConversion(o => o.Value, value => new SubjectId(value));
    }
}