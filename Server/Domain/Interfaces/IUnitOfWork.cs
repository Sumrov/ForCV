using System.Data;

namespace EslOnline.Domain.Interfaces;

public interface IUnitOfWork
{
    IDbConnection Connection { get; }
    Task<ITransaction> BeginTransactionAsync(IsolationLevel level);
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
