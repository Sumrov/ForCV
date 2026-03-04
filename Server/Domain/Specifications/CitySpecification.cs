using Ardalis.Specification;
using EslOnline.Domain.Aggregates;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Specifications;

//.AsNoTracking(); Если просто читаем, отключаем трекинг для скорости
public class CitySpecification : Specification<City>, ISingleResultSpecification<City>
{
    public CitySpecification(
        CityId? id = null,
        string? language = null
        )
    {
        if (id != null)
            Query.Where(u => u.Id == id);

        if (language != null)
            Query.Where(o => o.Language == language);
    }
}
