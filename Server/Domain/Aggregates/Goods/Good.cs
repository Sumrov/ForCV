using EslOnline.Domain.Primitives;
using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Aggregates.Goods;

public abstract class Good<TId>(
    long price,
    TId id,
    GoodType goodType,
    SubjectId ownerId,
    SubjectId productId
    )
    : AggregateRoot<TId>(id) where TId : struct
{
    protected Good() : this(default!, default!, default!, default!, default!) { } // для EF

    public long Price { get; protected set; } = price;
    public GoodType GoodType { get; protected set; } = goodType;
    public SubjectId OwnerId { get; protected set; } = ownerId;
    public SubjectId ProductId { get; protected set; } = productId;
}