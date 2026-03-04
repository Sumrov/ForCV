using EslOnline.Domain.Aggregates;
using EslOnline.Domain.Aggregates.Subjects;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Factory;

public class UserFactory(CitizenFactory citizenFactory)
{
    public (User, Citizen, BankAccount) Create(
        string name,
        string gmail,
        string language,
        BuildingId citizenLocationBuildingId,
        Government government,
        string? profilePictureURL = null,
        string? telegram = null
        )
    {
        (Citizen citizen, BankAccount bankAccount) = citizenFactory.Create(
            name,
            citizenLocationBuildingId,
            government
            );

        User user = User.Create(
            gmail: gmail,
            language: language,
            citizenId: citizen.Id
            );

        return (user, citizen, bankAccount);
    }
}