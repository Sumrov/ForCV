using EslOnline.Domain.Exceptions;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.ValueObjects;

public record MovableGoodLocation(
    CitizenId? CitizenId,
    VehicleId? VehicleId,
    RoomId? RoomId,
    BuildingId? BuildingId,
    bool IsInFridge
    )
{
    protected MovableGoodLocation() : this(default!, default!, default!, default!, default!) { } // для EF

    public static MovableGoodLocation Create(
        CitizenId? CitizenId = null,
        VehicleId? VehicleId = null,
        RoomId? RoomId = null,
        BuildingId? BuildingId = null,
        bool IsInFridge = false
        )
    {
        int count = 0;
        if (CitizenId != null) count++;
        if (VehicleId != null) count++;
        if (RoomId != null) count++;
        if (BuildingId != null) count++;
        if (count != 1) throw new DomainException("Нужно указать хотя бы одно местоположение");

        if(IsInFridge && RoomId == null) throw new DomainException("Холодильник может быть только в помещении");

        return new MovableGoodLocation(
            CitizenId: CitizenId,
            VehicleId: VehicleId,
            RoomId: RoomId,
            BuildingId: BuildingId,
            IsInFridge: IsInFridge
            );
    }
};
