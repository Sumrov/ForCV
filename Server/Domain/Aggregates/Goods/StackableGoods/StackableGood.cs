using EslOnline.Domain.Exceptions;
using EslOnline.Domain.Interfaces;
using EslOnline.Domain.ValueObjects;
using EslOnline.SharedKernel.Domain.Constants;
using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.Extensions;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Aggregates.Goods.StackableGoods;

public class StackableGood(
    int weight,
    int volume,
    long price,
    GoodType goodType,
    StackableGoodId id,
    SubjectId ownerId,
    SubjectId productId,
    MovableGoodLocation movebleGoodLocation
    )
    : Good<StackableGoodId>(price, id, goodType, ownerId, productId), IMovable
{
    protected StackableGood() : this(default!, default!, default!, default!, default!, default!, default!, default!) { } // для EF

    public int Weight { get; private set; } = weight;
    public int Volume { get; private set; } = volume;
    public MovableGoodLocation MovebleGoodLocation { get; private set; } = movebleGoodLocation;

    public static StackableGood Create(
        int weight,
        int volume,
        GoodType goodType,
        SubjectId ownerId,
        SubjectId productId,
        MovableGoodLocation movebleGoodLocation
        )
    {
        if (!goodType.IsAllowedFor(AllowedForMarkers.Stackable))
            throw new DomainException($"Тип {goodType} недопустим для {nameof(StackableGood)} товара");

        StackableGoodId id = new(Guid.CreateVersion7());

        return new(
            weight: weight,
            volume: volume,
            price: 0,
            goodType: goodType,
            id: id,
            ownerId: ownerId,
            productId: productId,
            movebleGoodLocation: movebleGoodLocation
        );
    }
}

//public class StackableGood : Good
//{
//    public GoodType Category { get; private set; } // Enum: Food, Ammo, Materials...
//    public long Quantity { get; private set; }

//    public StackableGood(int id, int ownerId, int productId, GoodType category, long quantity)
//        : base(id, ownerId, productId)
//    {
//        if (quantity < 0) throw new DomainException("Количество не может быть отрицательным");

//        Category = category;
//        Quantity = quantity;
//    }

//    // Метод для объединения пачек
//    public void Add(long amount)
//    {
//        if (amount <= 0) return;
//        Quantity += amount;
//    }
//}
