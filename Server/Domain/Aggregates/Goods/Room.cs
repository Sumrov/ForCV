using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Aggregates.Goods;

public class Room(
    bool isCanRent,
    bool isCanSell,
    bool isCanContinueContract,
    int rentPeriod,
    int rentPayPeriod,
    int roomNumber,
    long price,
    long rentPenalty,
    long rentPay,
    SubjectId ownerId,
    SubjectId productId,
    RoomId id,
    BuildingId locationId
    )
    : Good<RoomId>(price, id, GoodType.Room, ownerId, productId)
{
    protected Room() : this(default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!) { } // для EF

    public bool IsCanRent { get; set; } = isCanRent;
    public bool IsCanSell { get; set; } = isCanSell;
    public bool IsCanContinueContract { get; set; } = isCanContinueContract;
    public int RentPeriod { get; set; } = rentPeriod;
    public int RentPayPeriod { get; set; } = rentPayPeriod;
    public int RoomNumber { get; set; } = roomNumber;
    public long RentPenalty { get; set; } = rentPenalty;
    public long RentPay { get; set; } = rentPay;
    public BuildingId LocationId { get; set; } = locationId;

    internal static Room Create(
        int roomNumber,
        SubjectId ownerId,
        SubjectId productId,
        BuildingId locationId
    )
    {
        RoomId id = new(Guid.CreateVersion7());
        return new(
            isCanRent: false,
            isCanSell: false,
            isCanContinueContract: false,
            rentPeriod: 0,
            rentPayPeriod: 0,
            roomNumber: roomNumber,
            price: 0,
            rentPenalty: 0,
            rentPay: 0,
            ownerId: ownerId,
            productId: productId,
            id: id,
            locationId: locationId
            );
    }
}

