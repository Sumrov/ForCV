using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Aggregates.Buildings;

public class Commercial(
    int positionX,
    int positionZ,
    int sizeX,
    int sizeZ,
    int cellSizeX,
    int cellSizeY,
    int cellSizeZ,
    BuildingRotation rotation,
    CityId locationId,
    CommercialId id,
    DateTime? constructionUpdateDate
    )
    : Building<CommercialId>(positionX, positionZ, sizeX, sizeZ, cellSizeX, cellSizeY, cellSizeZ, id, rotation, locationId, constructionUpdateDate)
{
    protected Commercial() : this(default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!) { } // для EF

    internal static Commercial Create(
        (int X, int Z) position,
        (int X, int Z) size,
        (int X, int Y, int Z) cellSize,
        BuildingRotation rotation,
        CityId locationId
    )
    {
        CommercialId id = new(Guid.CreateVersion7());
        return new Commercial(
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
            constructionUpdateDate: DateTime.MaxValue);
    }

    //internal override void EnsureValidCreateState(int roomCount)
    //{
    //    base.EnsureValidCreateState(roomCount);
    //}
}

