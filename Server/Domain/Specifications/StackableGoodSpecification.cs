using Ardalis.Specification;
using EslOnline.Domain.Aggregates.Goods.StackableGoods;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Specifications;

//.AsNoTracking(); Если просто читаем, отключаем трекинг для скорости
public class StackableGoodSpecification : Specification<StackableGood>, ISingleResultSpecification<StackableGood>
{
    public StackableGoodSpecification(
        StackableGoodId? id = null,
        SubjectId? ownerId = null
        )
    {
        if (id != null)
            Query.Where(o => o.Id == id);

        if (ownerId != null)
            Query.Where(o => o.OwnerId == ownerId);
    }
}
