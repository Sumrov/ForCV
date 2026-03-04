using EslOnline.SharedKernel.Domain.Enums;

namespace EslOnline.SharedKernel.Domain.Interfaces
{
    public interface IBuildingExtension
    {
        int PositionX { get; }
        int PositionZ { get; }
        int SizeX { get; }
        int SizeZ { get; }
        int CellSizeX { get; }
        int CellSizeY { get; }
        int CellSizeZ { get; }
        BuildingRotation Rotation { get; }
    }
}