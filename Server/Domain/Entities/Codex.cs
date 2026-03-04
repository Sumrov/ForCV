using EslOnline.Domain.Primitives;
using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Entities;

public class Codex(
    bool immunityCivilServants,
    bool isCanRegionLeaderDissolveLegislative,
    bool isCanRegionLeaderSetControlledRegionLeader,
    int enforcmentDepartmentMaxEmployeers,
    int citizenProfitPercentTax,
    int companyProfitPercentTax,
    long enforcmentDepartmentEmployeersSalary,
    long registrationCompanyFee,
    long electionRegestrationFee,
    long regionHeadSalary,
    long legislatorsSalary,
    long headEnforcmentSalary,
    long headFinancialSalary,
    long headUrbanSalary,
    long headForeignRelationsSalary,
    long headJusticeSalary,
    HeadRegionPeriod headRegionPeriod,
    LegislatorCount legislatorCount,
    CodexId id
    )
    : Entity<CodexId>(id)
{
    protected Codex() : this(default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!, default!) { } // для EF

    public bool ImmunityCivilServants { get; private set; } = immunityCivilServants;
    public bool IsCanRegionLeaderDissolveLegislative { get; private set; } = isCanRegionLeaderDissolveLegislative;
    /// <summary>
    /// Может ли лидер региона назначать лидера подконтрольного региона (если нет тогда процесс выбора должен происходить через голосование)
    /// </summary>
    public bool IsCanRegionLeaderSetControlledRegionLeader { get; private set; } = isCanRegionLeaderSetControlledRegionLeader;
    public int EnforcmentDepartmentMaxEmployeers { get; private set; } = enforcmentDepartmentMaxEmployeers;
    public int CitizenProfitPercentTax { get; private set; } = citizenProfitPercentTax;
    public int CompanyProfitPercentTax { get; private set; } = companyProfitPercentTax;
    public long EnforcmentDepartmentEmployeersSalary { get; private set; } = enforcmentDepartmentEmployeersSalary;
    public long RegistrationCompanyFee { get; private set; } = registrationCompanyFee;
    public long ElectionRegestrationFee { get; private set; } = electionRegestrationFee;
    public long RegionHeadSalary { get; private set; } = regionHeadSalary;
    public long LegislatorsSalary { get; private set; } = legislatorsSalary;
    public long HeadEnforcmentSalary { get; private set; } = headEnforcmentSalary;
    public long HeadFinancialSalary { get; private set; } = headFinancialSalary;
    public long HeadUrbanSalary { get; private set; } = headUrbanSalary;
    public long HeadForeignRelationsSalary { get; private set; } = headForeignRelationsSalary;
    public long HeadJusticeSalary { get; private set; } = headJusticeSalary;
    public HeadRegionPeriod LeaderPeriod { get; private set; } = headRegionPeriod;
    public LegislatorCount LegislatorsCount { get; private set; } = legislatorCount;

    public static Codex Create()
    {
        CodexId codexId = new(Guid.CreateVersion7());
        const HeadRegionPeriod headRegionPeriod = HeadRegionPeriod.OneYear;
        const LegislatorCount legislatorCount = LegislatorCount.OneCityOneMember;

        return new Codex(
            immunityCivilServants: false,
            isCanRegionLeaderDissolveLegislative: false,
            isCanRegionLeaderSetControlledRegionLeader: false,
            enforcmentDepartmentMaxEmployeers: 0,
            citizenProfitPercentTax: 0,
            companyProfitPercentTax: 0,
            enforcmentDepartmentEmployeersSalary: 0,
            registrationCompanyFee: 0,
            electionRegestrationFee: 0,
            regionHeadSalary: 0,
            legislatorsSalary: 0,
            headEnforcmentSalary: 0,
            headFinancialSalary: 0,
            headUrbanSalary: 0,
            headForeignRelationsSalary: 0,
            headJusticeSalary: 0,
            headRegionPeriod: headRegionPeriod,
            legislatorCount: legislatorCount
,
            id: codexId);
    }
}