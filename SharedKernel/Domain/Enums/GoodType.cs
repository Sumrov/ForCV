using EslOnline.SharedKernel.Domain.Attributes;
using EslOnline.SharedKernel.Domain.Constants;

namespace EslOnline.SharedKernel.Domain.Enums;

public enum GoodType
{
    // Complication goodds
    Ammunition,
    Armor,
    Weapon,

    CitizenVehicle,
    MilitaryVehicle,

    Room,

    ProductionEquipment,
    RepairEquipment,
    DevelopingEquipment,

    // Stackable goods
    [AllowedFor(AllowedForMarkers.Stackable)]
    [AllowedFor(AllowedForMarkers.MicrobusinessProduction)] Grocery,
    [AllowedFor(AllowedForMarkers.Stackable)]
    [AllowedFor(AllowedForMarkers.MicrobusinessProduction)] Material,
    [AllowedFor(AllowedForMarkers.Stackable)] Medical,
    [AllowedFor(AllowedForMarkers.Stackable)] Fuel,
    [AllowedFor(AllowedForMarkers.Stackable)] Alcohol,
    [AllowedFor(AllowedForMarkers.Stackable)] Drug,
    [AllowedFor(AllowedForMarkers.Stackable)] SharePackage,
}