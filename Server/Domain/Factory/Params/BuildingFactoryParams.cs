using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Factory.Params;

public record BuildingFactoryParams(
    (int X, int Z) Position,
    (int X, int Z) Size,
    (int X, int Y, int Z) CellSize,
    BuildingRotation Rotation,
    CityId LocationId,
    SubjectId OwnerId,
    SubjectId ProductId
);
