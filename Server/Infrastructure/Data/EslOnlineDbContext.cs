using EslOnline.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EslOnline.Infrastructure.Data;

public class EslOnlineDbContext(DbContextOptions<EslOnlineDbContext> options) : DbContext(options), IUnitOfWork
{
    public IDbConnection Connection => Database.GetDbConnection();

    public async Task<ITransaction> BeginTransactionAsync(IsolationLevel level)
    {
        var transaction = await Database.BeginTransactionAsync(level);
        return new EntityFrameworkTransaction(transaction);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EslOnlineDbContext).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<Enum>().HaveConversion<string>();
        builder.Properties<string>().HaveMaxLength(100);
    }
}