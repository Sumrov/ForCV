using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.ValueObjects;

public record CitizenLocation(
    bool IsDriver,
    CitizenMoveMode CitizenMoveMode,
    BuildingId BuildingId,
    CityId CityId,
    BuildingId? TargetBuildingId,
    VehicleId? VehicleId,
    VehicleId? PublicVehicleId,
    DateTime? StartMoveDate
    )
{
    protected CitizenLocation() : this(default!, default!, default!, default!, default!, default!, default!, default!) { }

    internal static CitizenLocation Create(
        BuildingId BuildingId,
        CityId CityId,
        bool isDriver = false,
        CitizenMoveMode citizenMoveMode = CitizenMoveMode.Walk,
        BuildingId? targetBuildingId = null,
        VehicleId? vehicleId = null,
        VehicleId? publicVehicleId = null,
        DateTime? startMoveDate = null
        )
    {
        return new CitizenLocation(
            IsDriver: isDriver,
            CitizenMoveMode: citizenMoveMode,
            BuildingId: BuildingId,
            CityId: CityId,
            TargetBuildingId: targetBuildingId,
            VehicleId: vehicleId,
            PublicVehicleId: publicVehicleId,
            StartMoveDate: startMoveDate
            );
    }
}
