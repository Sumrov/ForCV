using Ardalis.Specification.EntityFrameworkCore;
using EslOnline.Domain.Interfaces;
using EslOnline.Infrastructure.Data;

namespace EslOnline.Infrastructure.Repositories;

public class EntityFrameworkRepository<T>(EslOnlineDbContext context) : RepositoryBase<T>(context), IRepository<T> where T : class
{
    // RepositoryBase из библиотеки Ardalis уже содержит методы:
    // ListAsync, GetByIdAsync, AddAsync, UpdateAsync, DeleteAsync и т.д.

    //// Мы можем добавить свой SaveAsync для удобства, если хотим
    //public async Task SaveAsync(T entity, CancellationToken ct = default)
    //{
    //    // Если сущность новая — добавит, если старая — обновит (EF сам разрулит стейт)
    //    context.Update(entity);
    //    await context.SaveChangesAsync(ct);
    //}
}