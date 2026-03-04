using EslOnline.Domain.Exceptions;
using EslOnline.SharedKernel.Domain.Constants;
using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.Extensions;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Aggregates.Buildings;

public class Microbusiness(
    int positionX,
    int positionZ,
    int sizeX,
    int sizeZ,
    int cellSizeX,
    int cellSizeY,
    int cellSizeZ,
    BuildingRotation rotation,
    GoodType production,
    CitizenId ownerId,
    MicrobusinessId id,
    CityId locationId,
    DateTime? constructionUpdateDate
    )
    : Building<MicrobusinessId>(positionX, positionZ, sizeX, sizeZ, cellSizeX, cellSizeY, cellSizeZ, id, rotation, locationId, constructionUpdateDate)
{
    protected Microbusiness() : this(default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!) { } // для EF

    public CitizenId OwnerId { get; private set; } = ownerId;
    public GoodType Production { get; private set; } = production;

    public static Microbusiness Create(
        (int X, int Z) position,
        BuildingRotation rotation,
        GoodType production,
        CitizenId ownerId,
        CityId locationId
        )
    {
        if (!production.IsAllowedFor(AllowedForMarkers.MicrobusinessProduction))
            throw new DomainException($"Тип {production} недопустим в качестве производства в {nameof(Microbusiness)}");

        MicrobusinessId id = new(Guid.CreateVersion7());
        return new Microbusiness(
            positionX: position.X,
            positionZ: position.Z,
            sizeX: 10,
            sizeZ: 10,
            cellSizeX: 1,
            cellSizeY: 1,
            cellSizeZ: 1,
            rotation: rotation,
            production: production,
            ownerId: ownerId,
            id: id,
            locationId: locationId,
            constructionUpdateDate: DateTime.MaxValue);
    }
}
