using Ardalis.Specification;
using EslOnline.Domain.Aggregates.Subjects;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Specifications;

//.AsNoTracking(); Если просто читаем, отключаем трекинг для скорости
public class GovernmentSpecification : Specification<Government>, ISingleResultSpecification<Government>
{
    public GovernmentSpecification(
        GovernmentId? id = null,
        CityId? locationId = null
        )
    {
        if (id != null)
            Query.Where(o => o.Id == id);

        if (locationId != null)
            Query.Where(o => o.LocationId == locationId);
    }
}
