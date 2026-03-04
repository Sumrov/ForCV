using Ardalis.Specification;
using EslOnline.Domain.Aggregates;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Specifications;

//.AsNoTracking(); Если просто читаем, отключаем трекинг для скорости
public class BankAccountSpecification : Specification<BankAccount>, ISingleResultSpecification<BankAccount>
{
    public BankAccountSpecification(
        BancAccountId? id = null,
        SubjectId? ownerId = null,
        CurrencyId? currencyId = null
        )
    {
        if (id != null)
            Query.Where(o => o.Id == id);

        if (ownerId != null)
            Query.Where(o => o.OwnerId == ownerId);

        if (currencyId != null)
            Query.Where(o => o.CurrencyId == currencyId);
    }
}
