using Ardalis.Specification;
using EslOnline.Domain.Aggregates.Buildings;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Specifications;

//.AsNoTracking(); Если просто читаем, отключаем трекинг для скорости
public class SquareSpecification : Specification<Square>, ISingleResultSpecification<Square>
{
    public SquareSpecification(
        CityId? locationId = null
        )
    {
        if (locationId != null)
            Query.Where(o => o.LocationId == locationId);
    }
}
