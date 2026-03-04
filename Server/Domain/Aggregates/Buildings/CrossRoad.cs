using EslOnline.Domain.Exceptions;
using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Aggregates.Buildings;

public class CrossRoad(
    int positionX,
    int positionZ,
    int sizeX,
    int sizeZ,
    int cellSizeX,
    int cellSizeY,
    int cellSizeZ,
    BuildingMaterial buildingMaterial,
    BuildingRotation rotation,
    CityId locationId,
    CrossRoadId id,
    DateTime? constructionUpdateDate
    )
    : Building<CrossRoadId>(positionX, positionZ, sizeX, sizeZ, cellSizeX, cellSizeY, cellSizeZ, id, rotation, locationId, constructionUpdateDate)
{
    protected CrossRoad() : this(default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!) { } // для EF

    public BuildingMaterial BuildingMaterial { get; private set; } = buildingMaterial;

    public static CrossRoad Create(
        (int X, int Z) position,
        BuildingMaterial buildingMaterial,
        CityId locationId
        )
    {
        if (buildingMaterial is not (BuildingMaterial.Asphalt or BuildingMaterial.Ground))
            throw new DomainException($"Перекрёсток должен быть либо {nameof(BuildingMaterial.Asphalt)} либо {nameof(BuildingMaterial.Ground)}");

        CrossRoadId id = new(Guid.CreateVersion7());
        return new CrossRoad(
            positionX: position.X,
            positionZ: position.Z,
            sizeX: 10,
            sizeZ: 10,
            cellSizeX: 1,
            cellSizeY: 1,
            cellSizeZ: 1,
            buildingMaterial: buildingMaterial,
            rotation: BuildingRotation.Zero,
            locationId: locationId,
            id: id,
            constructionUpdateDate: DateTime.MaxValue);
    }
}

