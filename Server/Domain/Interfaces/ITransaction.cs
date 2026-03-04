using System.Data;

namespace EslOnline.Domain.Interfaces;

public interface ITransaction : IAsyncDisposable
{
    IDbTransaction DbTransaction { get; }
    Task CommitAsync(CancellationToken ct = default);
    Task RollbackAsync(CancellationToken ct = default);
}
