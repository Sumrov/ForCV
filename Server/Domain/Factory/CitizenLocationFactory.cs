using EslOnline.Domain.ValueObjects;
using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Factory;

public class CitizenLocationFactory(
    //IRepository<Vehicle> vehicleRepository
    )
{
    public CitizenLocation CreateWalkMove(BuildingId target, BuildingId buildingId, CityId cityId)
    {
        return new CitizenLocation(
            false,
            CitizenMoveMode.Walk,
            buildingId,
            cityId,
            target,
            null,
            null,
            DateTime.UtcNow
            );
    }

    //public CitizenLocation CreateOwnVehicle(BuildingId target, BuildingId buildingId, CityId cityId, VehicleId vehicleId)
    //{
    //    // TODO проверка на право использования авто
    //    return new CitizenLocation(
    //        true,
    //        CitizenMoveMode.OwnVehicle,
    //        buildingId,
    //        cityId,
    //        target,
    //        vehicleId,
    //        null,
    //        DateTime.UtcNow
    //        );
    //}

    //public CitizenLocation CreatePublicVehicle(BuildingId target, BuildingId buildingId, CityId cityId, VehicleId publicVehicleId)
    //{
    //    return new CitizenLocation(
    //        false,
    //        CitizenMoveMode.Walk,
    //        buildingId,
    //        cityId,
    //        target,
    //        null,
    //        publicVehicleId,
    //        DateTime.UtcNow
    //        );
    //}
}
