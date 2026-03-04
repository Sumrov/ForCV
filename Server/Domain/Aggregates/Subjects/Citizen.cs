using EslOnline.Domain.ValueObjects;
using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Aggregates.Subjects;

public class Citizen(
    bool isMissingPerson,
    bool isBankrupt,
    float stress,
    float health,
    float hunger,
    string name,
    CitizenId id,
    CityId bornId,
    GovernmentId citizenshipId,
    DateTime? cold,
    DateTime? injury,
    DateTime? alcoholIntoxication,
    DateTime? drugsIntoxication,
    DateTime? drugAddiction,
    DateTime? alcoholAddiction,
    DateTime? bankruptcyDate,
    CitizenLocation location,
    JobPosition? job
    )
    : Subject<CitizenId>(isBankrupt, name, id, bankruptcyDate)
{
    protected Citizen() : this(default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!) { } // для EF

    public bool IsMissingPerson { get; private set; } = isMissingPerson;
    public float Stress { get; private set; } = stress;
    public float Health { get; private set; } = health;
    public float Hunger { get; private set; } = hunger;
    public CityId BornId { get; private set; } = bornId;
    public GovernmentId CitizenshipId { get; private set; } = citizenshipId;
    public DateTime? Cold { get; private set; } = cold;
    public DateTime? Injury { get; private set; } = injury;
    public DateTime? AlcoholIntoxication { get; private set; } = alcoholIntoxication;
    public DateTime? DrugsIntoxication { get; private set; } = drugsIntoxication;
    public DateTime? DrugAddiction { get; private set; } = drugAddiction;
    public DateTime? AlcoholAddiction { get; private set; } = alcoholAddiction;
    public CitizenLocation Location { get; private set; } = location;
    public JobPosition? Job { get; private set; } = job;

    internal static Citizen Create(
        string name,
        CityId born,
        GovernmentId citizenship,
        BuildingId citizenLocationBuildingId
        )
    {
        CitizenId citizenId = new(Guid.CreateVersion7());
        CitizenLocation citizenLocation = new(
            false,
            CitizenMoveMode.Walk,
            citizenLocationBuildingId,
            born,
            null,
            null,
            null,
            null);

        return new(
            isMissingPerson: false,
            isBankrupt: false,
            stress: 0,
            health: 0,
            hunger: 0,
            name: name,
            id: citizenId,
            bornId: born,
            citizenshipId: citizenship,
            cold: null,
            injury: null,
            alcoholIntoxication: null,
            drugsIntoxication: null,
            drugAddiction: null,
            alcoholAddiction: null,
            bankruptcyDate: null,
            location: citizenLocation,
            job: null
            );
    }
}
