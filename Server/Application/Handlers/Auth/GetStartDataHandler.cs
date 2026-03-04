using Dapper;
using EslOnline.Domain.Aggregates.Subjects;
using EslOnline.Domain.Extensions;
using EslOnline.Domain.Interfaces;
using EslOnline.Domain.Specifications;
using EslOnline.SharedKernel.Application.Requests;
using EslOnline.SharedKernel.Application.Responses;
using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;
using MediatR;

namespace EslOnline.Application.Handlers.Auth;

public class GetStartDataHandler(
    IUnitOfWork unitOfWork,
    IRepository<Citizen> citizenRepo
    )
    : IRequestHandler<GetStartDataRequest, GetStartDataResponse>
{
    public async Task<GetStartDataResponse> Handle(GetStartDataRequest request, CancellationToken cancellationToken)
    {
        const string sqlReq = $@"
            SELECT 
                ba.Balance                      AS {nameof(SqlDto.Balance)},
                citizenship.Name                AS {nameof(SqlDto.Citizenship)},
                gov.Currency_ShortName          AS {nameof(SqlDto.CurrencyShortName)},
                sg.GoodType                     AS {nameof(SqlDto.CitizenBaggageStr)},
                c.Location_TargetBuildingId     AS {nameof(SqlDto.TargetLocationIdGuid)}
            FROM Citizen c
            JOIN Government gov         ON gov.LocationId   = c.Location_CityId
            JOIN BankAccount ba         ON ba.OwnerId       = c.Id AND ba.CurrencyId = gov.Currency_Id
            JOIN Government citizenship ON citizenship.Id   = c.CitizenshipId
            LEFT JOIN StackableGood sg  ON sg.OwnerId       = c.Id
            WHERE c.Id = @CitizenId";
        var sqlDto = await unitOfWork.Connection.QuerySingleAsync<SqlDto>(
            sql: sqlReq,
            param: new { CitizenId = request.CitizenId.Value });
        var specification = new CitizenSpecification(id: request.CitizenId);
        var citizen = await citizenRepo.SingleAsync(specification, ct: cancellationToken);

        return new(
            Productivity: citizen.GetProductivity(),
            Stress: citizen.Stress,
            Health: citizen.Health,
            Hunger: citizen.Hunger,
            Balance: sqlDto.Balance,
            Name: citizen.Name,
            Citizenship: sqlDto.Citizenship,
            CurrencyShortName: sqlDto.CurrencyShortName,
            CitizenBaggage: sqlDto.CitizenBaggage,
            CitizenLocationId: citizen.Location.BuildingId,
            TargetLocationId: sqlDto.TargetLocationId
            );
    }
    private sealed record SqlDto(
        long Balance,
        string Citizenship,
        string CurrencyShortName,
        string? CitizenBaggageStr,
        Guid? TargetLocationIdGuid
        )
    {
        public GoodType? CitizenBaggage => CitizenBaggageStr != null
            ? Enum.Parse<GoodType>(CitizenBaggageStr)
            : null;
        public BuildingId? TargetLocationId => TargetLocationIdGuid.HasValue
            ? new BuildingId(TargetLocationIdGuid.Value)
            : null;
    };
}