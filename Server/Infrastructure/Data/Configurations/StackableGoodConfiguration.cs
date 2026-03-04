using EslOnline.Domain.Aggregates.Goods.StackableGoods;
using EslOnline.SharedKernel.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EslOnline.Infrastructure.Data.Configurations;

public class StackableGoodConfiguration : IEntityTypeConfiguration<StackableGood>
{
    public void Configure(EntityTypeBuilder<StackableGood> builder)
    {
        builder.Property(o => o.Id).HasConversion(o => o.Value, value => new StackableGoodId(value));
        builder.Property(o => o.OwnerId).HasConversion(o => o.Value, value => new SubjectId(value));
        builder.Property(o => o.ProductId).HasConversion(o => o.Value, value => new SubjectId(value));
        builder.OwnsOne(o => o.MovebleGoodLocation, o =>
        {
            o.Property(o => o.RoomId).HasConversion(
                o => o.HasValue ? o.Value.Value : (Guid?)null,
                o => o.HasValue ? new RoomId(o.Value) : null)
            .IsRequired(false);
            o.Property(o => o.CitizenId).HasConversion(
                o => o.HasValue ? o.Value.Value : (Guid?)null,
                o => o.HasValue ? new CitizenId(o.Value) : null)
            .IsRequired(false);
            o.Property(o => o.BuildingId).HasConversion(
                o => o.HasValue ? o.Value.Value : (Guid?)null,
                o => o.HasValue ? new BuildingId(o.Value) : null)
            .IsRequired(false);
            o.Property(o => o.VehicleId).HasConversion(
                o => o.HasValue ? o.Value.Value : (Guid?)null,
                o => o.HasValue ? new VehicleId(o.Value) : null)
            .IsRequired(false);
        });
    }
}