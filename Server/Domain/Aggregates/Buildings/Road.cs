using EslOnline.Domain.Exceptions;
using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Aggregates.Buildings;

public class Road(
    int positionX,
    int positionZ,
    int sizeX,
    int sizeZ,
    int cellSizeX,
    int cellSizeY,
    int cellSizeZ,
    BuildingMaterial buildingMaterial,
    BuildingRotation rotation,
    RoadId id,
    CityId locationId,
    DateTime? constructionUpdateDate
    )
    : Building<RoadId>(positionX, positionZ, sizeX, sizeZ, cellSizeX, cellSizeY, cellSizeZ, id, rotation, locationId, constructionUpdateDate)
{
    protected Road() : this(default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!) { } // для EF

    public BuildingMaterial BuildingMaterial { get; private set; } = buildingMaterial;

    public static Road Create(
        (int X, int Z) position,
        BuildingRotation rotation,
        BuildingMaterial buildingMaterial,
        CityId locationId
        )
    {
        if (rotation is not (BuildingRotation.Zero or BuildingRotation.Ninety))
            throw new DomainException($"Дорога допускает только повороты {nameof(BuildingRotation.Zero)} и {nameof(BuildingRotation.Ninety)}");
        if (buildingMaterial is not (BuildingMaterial.Asphalt or BuildingMaterial.Ground))
            throw new DomainException($"Дорога должна быть либо {nameof(BuildingMaterial.Asphalt)} либо {nameof(BuildingMaterial.Ground)}");

        RoadId id = new(Guid.CreateVersion7());
        return new Road(
            positionX: position.X,
            positionZ: position.Z,
            sizeX: 10,
            sizeZ: 10,
            cellSizeX: 1,
            cellSizeY: 1,
            cellSizeZ: 1,
            buildingMaterial: buildingMaterial,
            rotation: rotation,
            id: id,
            locationId: locationId,
            constructionUpdateDate: DateTime.MaxValue);
    }
}
