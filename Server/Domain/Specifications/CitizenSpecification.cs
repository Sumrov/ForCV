using Ardalis.Specification;
using EslOnline.Domain.Aggregates.Subjects;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Specifications;

//.AsNoTracking(); Если просто читаем, отключаем трекинг для скорости
public class CitizenSpecification : Specification<Citizen>, ISingleResultSpecification<Citizen>
{
    public CitizenSpecification(
        CitizenId? id = null
        )
    {
        if (id != null)
            Query.Where(o => o.Id == id);
    }
}
