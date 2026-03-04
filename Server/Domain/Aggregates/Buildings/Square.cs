using EslOnline.Domain.Exceptions;
using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Aggregates.Buildings;

public class Square(
    int positionX,
    int positionZ,
    int sizeX,
    int sizeZ,
    int cellSizeX,
    int cellSizeY,
    int cellSizeZ,
    BuildingRotation rotation,
    BuildingMaterial buildingMaterial,
    SquareId id,
    CityId locationId,
    DateTime? constructionUpdateDate
    )
    : Building<SquareId>(positionX, positionZ, sizeX, sizeZ, cellSizeX, cellSizeY, cellSizeZ, id, rotation, locationId, constructionUpdateDate)
{
    protected Square() : this(default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!) { } // для EF

    public BuildingMaterial BuildingMaterial { get; private set; } = buildingMaterial;

    public static Square Create(
        BuildingMaterial buildingMaterial,
        CityId locationId
        )
    {
        if (buildingMaterial is not (BuildingMaterial.Asphalt or BuildingMaterial.Ground))
            throw new DomainException($"Площадь должна быть либо {nameof(BuildingMaterial.Asphalt)} либо {nameof(BuildingMaterial.Ground)}");

        SquareId id = new(Guid.CreateVersion7());
        return new Square(
            positionX: 0,
            positionZ: 0,
            sizeX: 100,
            sizeZ: 100,
            cellSizeX: 1,
            cellSizeY: 1,
            cellSizeZ: 1,
            rotation: BuildingRotation.OneHundredAndEighty,
            buildingMaterial: buildingMaterial,
            id: id,
            locationId: locationId,
            constructionUpdateDate: DateTime.MaxValue);
    }
}
