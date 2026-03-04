using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Aggregates.Buildings;

public class Tawnhall(
    int positionX,
    int positionZ,
    int sizeX,
    int sizeZ,
    int cellSizeX,
    int cellSizeY,
    int cellSizeZ,
    BuildingRotation rotation,
    TawnhallId id,
    CityId locationId,
    DateTime? constructionUpdateDate
    )
    : Building<TawnhallId>(positionX, positionZ, sizeX, sizeZ, cellSizeX, cellSizeY, cellSizeZ, id, rotation, locationId, constructionUpdateDate)
{
    protected Tawnhall() : this(default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!) { } // для EF

    public static Tawnhall Create(
        CityId locationId
    )
    {
        TawnhallId id = new(Guid.CreateVersion7());
        return new Tawnhall(
            positionX: 100,
            positionZ: 0,
            sizeX: 100,
            sizeZ: 100,
            cellSizeX: 1,
            cellSizeY: 1,
            cellSizeZ: 1,
            rotation: BuildingRotation.OneHundredAndEighty,
            id: id,
            locationId: locationId,
            constructionUpdateDate: DateTime.MaxValue);
    }
}


