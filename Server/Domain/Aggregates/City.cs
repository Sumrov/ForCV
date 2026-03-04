using EslOnline.Domain.Primitives;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Aggregates;

public class City(
    string name,
    string language,
    CityId id
    )
    : AggregateRoot<CityId>(id)
{
    protected City() : this(default!, default!, default!) { } // для EF

    public string Name { get; private set; } = name;
    public string Language { get; private set; } = language;

    internal static City Create(
        string name,
        string language
        )
    {
        CityId id = new(Guid.CreateVersion7());

        return new(
            name: name,
            language: language,
            id: id
            );
    }
}