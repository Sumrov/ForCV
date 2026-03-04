using EslOnline.Domain.Primitives;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Aggregates;

public class BankAccount(
    long balance,
    SubjectId ownerId,
    CurrencyId currencyId,
    BancAccountId id
    )
    : AggregateRoot<BancAccountId>(id)
{
    public long Balance { get; set; } = balance;
    public SubjectId OwnerId { get; set; } = ownerId;
    public CurrencyId CurrencyId { get; set; } = currencyId;

    public static BankAccount Create(
        SubjectId ownerId,
        CurrencyId currencyId
        )
    {
        BancAccountId id = Guid.CreateVersion7();
        return new(
            balance: 0,
            ownerId: ownerId,
            currencyId: currencyId,
            id: id
            );
    }
}