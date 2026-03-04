using EslOnline.Domain.Aggregates;
using EslOnline.Domain.Aggregates.Buildings;
using EslOnline.Domain.Aggregates.Subjects;

namespace EslOnline.Domain.Factory.Params;

public record CityFactoryResult(
    City City,
    BankAccount governmentBancAccount,
    Government Government,
    Tawnhall Townhall,
    Square Square,
    IReadOnlyList<CrossRoad> Crossroads,
    IReadOnlyList<Road> Roads);
