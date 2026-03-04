using EslOnline.Domain.Aggregates;
using EslOnline.Domain.Aggregates.Subjects;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Factory;

public class CitizenFactory
{
    public (Citizen, BankAccount) Create(
        string name,
        BuildingId citizenLocationBuildingId,
        Government government
        )
    {
        Citizen citizen = Citizen.Create(
            name,
            government.LocationId,
            government.Id,
            citizenLocationBuildingId
            );

        BankAccount bankAccount = BankAccount.Create(
            citizen.Id,
            government.Currency.Id
            );

        return (citizen, bankAccount);
    }
}