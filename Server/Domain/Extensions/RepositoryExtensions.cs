using Ardalis.Specification;

namespace EslOnline.Domain.Extensions;

public static class RepositoryExtensions
{
    public static async Task<T> SingleAsync<T>(
        this IRepositoryBase<T> repository,
        ISingleResultSpecification<T> spec, // ИЗМЕНЕНО: добавили ISingleResult...
        CancellationToken ct = default) where T : class
    {
        // Теперь SingleOrDefaultAsync примет эту спецификацию без ошибок
        var entity = await repository.SingleOrDefaultAsync(spec, ct);

        if (entity == null)
        {
            throw new Exception($"{typeof(T).Name} не найден");
        }

        return entity;
    }
}
