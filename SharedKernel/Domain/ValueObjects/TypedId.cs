using System;

namespace EslOnline.SharedKernel.Domain.ValueObjects;

// --- Goods ---
public readonly record struct GoodId(Guid Value)
{
    public static implicit operator GoodId(Guid value) => new(value);
}

public readonly record struct StackableGoodId(Guid Value)
{
    public static implicit operator StackableGoodId(Guid value) => new(value);
    public static implicit operator GoodId(StackableGoodId id) => new(id.Value);
}

public readonly record struct RoomId(Guid Value)
{
    public static implicit operator RoomId(Guid value) => new(value);
    public static implicit operator GoodId(RoomId id) => new(id.Value);
}

public readonly record struct CommercialRoomId(Guid Value)
{
    public static implicit operator CommercialRoomId(Guid value) => new(value);
    public static implicit operator RoomId(CommercialRoomId id) => new(id.Value);
}

public readonly record struct HomeRoomId(Guid Value)
{
    public static implicit operator HomeRoomId(Guid value) => new(value);
    public static implicit operator RoomId(HomeRoomId id) => new(id.Value);
}

public readonly record struct IndustrialRoomId(Guid Value)
{
    public static implicit operator IndustrialRoomId(Guid value) => new(value);
    public static implicit operator RoomId(IndustrialRoomId id) => new(id.Value);
}

// --- Subjects ---
public readonly record struct SubjectId(Guid Value)
{
    public static implicit operator SubjectId(Guid value) => new(value);
}

public readonly record struct CitizenId(Guid Value)
{
    public static implicit operator CitizenId(Guid value) => new(value);
    public static implicit operator SubjectId(CitizenId id) => new(id.Value);
}

public readonly record struct GovernmentId(Guid Value)
{
    public static implicit operator GovernmentId(Guid value) => new(value);
    public static implicit operator SubjectId(GovernmentId id) => new(id.Value);
}

public readonly record struct CompanyId(Guid Value)
{
    public static implicit operator CompanyId(Guid value) => new(value);
    public static implicit operator SubjectId(CompanyId id) => new(id.Value);
}

// --- Core Entities ---
public readonly record struct CityId(Guid Value)
{
    public static implicit operator CityId(Guid value) => new(value);
}

public readonly record struct UserId(Guid Value)
{
    public static implicit operator UserId(Guid value) => new(value);
}

public readonly record struct VehicleId(Guid Value)
{
    public static implicit operator VehicleId(Guid value) => new(value);
}

// --- Buildings ---
public readonly record struct BuildingId(Guid Value)
{
    public static implicit operator BuildingId(Guid value) => new(value);
}

public readonly record struct CommercialId(Guid Value)
{
    public static implicit operator CommercialId(Guid value) => new(value);
    public static implicit operator BuildingId(CommercialId id) => new(id.Value);
}

public readonly record struct CrossRoadId(Guid Value)
{
    public static implicit operator CrossRoadId(Guid value) => new(value);
    public static implicit operator BuildingId(CrossRoadId id) => new(id.Value);
}

public readonly record struct HomeId(Guid Value)
{
    public static implicit operator HomeId(Guid value) => new(value);
    public static implicit operator BuildingId(HomeId id) => new(id.Value);
}

public readonly record struct IndustrialId(Guid Value)
{
    public static implicit operator IndustrialId(Guid value) => new(value);
    public static implicit operator BuildingId(IndustrialId id) => new(id.Value);
}

public readonly record struct MicrobusinessId(Guid Value)
{
    public static implicit operator MicrobusinessId(Guid value) => new(value);
    public static implicit operator BuildingId(MicrobusinessId id) => new(id.Value);
}

public readonly record struct RoadId(Guid Value)
{
    public static implicit operator RoadId(Guid value) => new(value);
    public static implicit operator BuildingId(RoadId id) => new(id.Value);
}

public readonly record struct SquareId(Guid Value)
{
    public static implicit operator SquareId(Guid value) => new(value);
    public static implicit operator BuildingId(SquareId id) => new(id.Value);
}

public readonly record struct TawnhallId(Guid Value)
{
    public static implicit operator TawnhallId(Guid value) => new(value);
    public static implicit operator BuildingId(TawnhallId id) => new(id.Value);
}

// --- Other Entities ---
public readonly record struct CodexId(Guid Value)
{
    public static implicit operator CodexId(Guid value) => new(value);
}

public readonly record struct CurrencyId(Guid Value)
{
    public static implicit operator CurrencyId(Guid value) => new(value);
}

public readonly record struct DebtId(Guid Value)
{
    public static implicit operator DebtId(Guid value) => new(value);
}

public readonly record struct BancAccountId(Guid Value)
{
    public static implicit operator BancAccountId(Guid value) => new(value);
}