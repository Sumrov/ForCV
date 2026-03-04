using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Aggregates.Buildings;

public class Home(
    int positionX,
    int positionZ,
    int sizeX,
    int sizeZ,
    int cellSizeX,
    int cellSizeY,
    int cellSizeZ,
    BuildingRotation rotation,
    CityId locationId,
    HomeId id,
    DateTime? сonstructionUpdateDate
    )
    : Building<HomeId>(positionX, positionZ, sizeX, sizeZ, cellSizeX, cellSizeY, cellSizeZ, id, rotation, locationId, сonstructionUpdateDate)
{
    protected Home() : this(default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!) { } // для EF

    internal static Home Create(
        (int X, int Z) position,
        (int X, int Z) size,
        (int X, int Y, int Z) cellSize,
        BuildingRotation rotation,
        CityId locationId
    )
    {
        HomeId id = new(Guid.CreateVersion7());
        return new Home(
            positionX: position.X,
            positionZ: position.Z,
            sizeX: size.X,
            sizeZ: size.Z,
            cellSizeX: cellSize.X,
            cellSizeY: cellSize.Y,
            cellSizeZ: cellSize.Z,
            rotation: rotation,
            locationId: locationId,
            id: id,
            сonstructionUpdateDate: DateTime.MaxValue);
    }
}
