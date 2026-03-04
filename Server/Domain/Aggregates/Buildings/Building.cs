using EslOnline.Domain.Primitives;
using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Aggregates.Buildings;

public abstract class Building<TId>(
    int positionX,
    int positionZ,
    int sizeX,
    int sizeZ,
    int cellSizeX,
    int cellSizeY,
    int cellSizeZ,
    BuildingId id,
    BuildingRotation rotation,
    CityId locationId,
    DateTime? constructionUpdateDate
    )
    : AggregateRoot<BuildingId>(id) where TId : struct
{
    protected Building() : this(default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!) { } // для EF

    public int PositionX { get; set; } = positionX;
    public int PositionZ { get; set; } = positionZ;
    public int SizeX { get; set; } = sizeX;
    public int SizeZ { get; set; } = sizeZ;
    public int CellSizeX { get; set; } = cellSizeX;
    public int CellSizeY { get; set; } = cellSizeY;
    public int CellSizeZ { get; set; } = cellSizeZ;
    public BuildingRotation Rotation { get; set; } = rotation;
    public CityId LocationId { get; set; } = locationId;
    public DateTime? ConstructionUpdateDate { get; set; } = constructionUpdateDate;

    internal int MaxRooms => CellSizeX * CellSizeY * CellSizeZ;

    //internal virtual void EnsureValidCreateState(int roomCount)
    //{
    //    if (roomCount != MaxRooms)
    //        throw new DomainException($"здание должно иметь {MaxRooms} комнат");
    //}
}