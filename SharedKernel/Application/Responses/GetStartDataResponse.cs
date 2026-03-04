using EslOnline.SharedKernel.Application.Interfaces;
using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.SharedKernel.Application.Responses
{
    public sealed record GetStartDataResponse(
        float Productivity,
        float Stress,
        float Health,
        float Hunger,
        long Balance,
        string Name,
        string Citizenship,
        string CurrencyShortName,
        GoodType? CitizenBaggage,
        BuildingId CitizenLocationId,
        BuildingId? TargetLocationId
        )
        : IResponse;
}
