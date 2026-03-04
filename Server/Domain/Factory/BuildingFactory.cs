using EslOnline.Domain.Aggregates.Buildings;
using EslOnline.Domain.Aggregates.Goods;
using EslOnline.Domain.Factory.Params;

namespace EslOnline.Domain.Factory;

public class BuildingFactory
{
    public (Home, IReadOnlyList<Room>) CreateHome(BuildingFactoryParams p)
    {
        var building = Home.Create(p.Position, p.Size, p.CellSize, p.Rotation, p.LocationId);
        var dfv = building.Id;
        var rooms = Enumerable
            .Range(1, building.MaxRooms)
            .Select(i => Room.Create(i, p.OwnerId, p.ProductId, building.Id))
            .ToList();

        return (building, rooms);
    }

    public (Commercial, IReadOnlyList<Room>) CreateCommercial(BuildingFactoryParams p)
    {
        var building = Commercial.Create(p.Position, p.Size, p.CellSize, p.Rotation, p.LocationId);
        var dsv = building.Id;

        var rooms = Enumerable
            .Range(1, building.MaxRooms)
            .Select(i => Room.Create(i, p.OwnerId, p.ProductId, building.Id))
            .ToList();

        return (building, rooms);
    }

    public (Industrial, IReadOnlyList<Room>) CreateIndustrial(BuildingFactoryParams p)
    {
        var building = Industrial.Create(p.Position, p.Size, p.CellSize, p.Rotation, p.LocationId);

        var rooms = Enumerable
            .Range(1, building.MaxRooms)
            .Select(i => Room.Create(i, p.OwnerId, p.ProductId, building.Id))
            .ToList();

        return (building, rooms);
    }
}