using EslOnline.Domain.Aggregates;
using EslOnline.SharedKernel.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EslOnline.Infrastructure.Data.Configurations;

public class BancAccountConfiguration : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.Property(o => o.Id).HasConversion(o => o.Value, value => new BancAccountId(value));
        builder.Property(o => o.OwnerId).HasConversion(o => o.Value, value => new SubjectId(value));
        builder.Property(o => o.CurrencyId).HasConversion(o => o.Value, value => new CurrencyId(value));
    }
}