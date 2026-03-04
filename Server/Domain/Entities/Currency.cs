using EslOnline.Domain.Primitives;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Entities;

public class Currency(
    string name,
    string shortName,
    CurrencyId id
    )
    : Entity<CurrencyId>(id)
{
    protected Currency() : this(default!, default!, default!) { } // для EF

    public string Name { get; private set; } = name;
    public string ShortName { get; private set; } = shortName;

    public static Currency Create(string name, string shortName)
    {
        CurrencyId currencyId = new(Guid.CreateVersion7());

        return new(
            name: name,
            shortName: shortName,
            id: currencyId
            );
    }
}