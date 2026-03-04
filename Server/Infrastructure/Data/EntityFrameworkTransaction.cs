using EslOnline.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace EslOnline.Infrastructure.Data;

public class EntityFrameworkTransaction(IDbContextTransaction transaction) : ITransaction
{
    public IDbTransaction DbTransaction =>
        transaction.GetDbTransaction();

    public Task CommitAsync(CancellationToken ct = default)
        => transaction.CommitAsync(ct);

    public Task RollbackAsync(CancellationToken ct = default)
        => transaction.RollbackAsync(ct);

    public ValueTask DisposeAsync()
        => transaction.DisposeAsync();
}
