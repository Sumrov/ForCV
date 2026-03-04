using EslOnline.Domain.Entities;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Aggregates.Subjects;

public class Government(
    bool isBankrupt,
    string name,
    GovernmentId id,
    CityId locationId,
    DateTime? bankruptcyDate,
    DateTime? headRegionAppointment,
    GovernmentId? headGovernmentId,
    Codex codex,
    Currency currency
    )
    : Subject<GovernmentId>(isBankrupt, name, id, bankruptcyDate)
{
    protected Government() : this(default!, default!, default!, default!, default!, default!, default!, default!, default!) { } // для EF

    public CityId LocationId { get; private set; } = locationId;
    public DateTime? HeadRegionAppointment { get; private set; } = headRegionAppointment;
    public GovernmentId? HeadGovernmentId { get; private set; } = headGovernmentId;
    public Codex Codex { get; private set; } = codex;
    public Currency Currency { get; private set; } = currency;

    public static (Government, BankAccount) Create(
        string name,
        CityId locationId
        )
    {
        GovernmentId governmentId = new(Guid.CreateVersion7());
        Codex codex = Codex.Create();
        Currency currency = Currency.Create(name + "Currency", name[..2]);

        Government government = new(
            isBankrupt: false,
            name: name,
            id: governmentId,
            locationId: locationId,
            bankruptcyDate: null,
            headRegionAppointment: null,
            headGovernmentId: null,
            codex: codex,
            currency: currency
            );

        BankAccount bankAccount = BankAccount.Create(
            government.Id, 
            government.Currency.Id
            );

        return (government, bankAccount);
    }
}