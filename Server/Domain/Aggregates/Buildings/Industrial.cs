using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Aggregates.Buildings;

public class Industrial(
    int positionX,
    int positionZ,
    int sizeX,
    int sizeZ,
    int cellSizeX,
    int cellSizeY,
    int cellSizeZ,
    BuildingRotation rotation,
    IndustrialId id,
    CityId locationId,
    DateTime? constructionUpdateDate
    )
    : Building<IndustrialId>(positionX, positionZ, sizeX, sizeZ, cellSizeX, cellSizeY, cellSizeZ, id, rotation, locationId, constructionUpdateDate)
{
    protected Industrial() : this(default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!) { } // для EF

    internal static Industrial Create(
        (int X, int Z) position,
        (int X, int Z) size,
        (int X, int Y, int Z) cellSize,
        BuildingRotation rotation,
        CityId locationId
    )
    {
        IndustrialId id = new(Guid.CreateVersion7());
        return new Industrial(
            positionX: position.X,
            positionZ: position.Z,
            sizeX: size.X,
            sizeZ: size.Z,
            cellSizeX: cellSize.X,
            cellSizeY: cellSize.Y,
            cellSizeZ: cellSize.Z,
            rotation: rotation,
            id: id,
            locationId: locationId,
            constructionUpdateDate: DateTime.MaxValue);
    }
}
