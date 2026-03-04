using EslOnline.Domain.Primitives;

namespace EslOnline.Domain.Aggregates.Subjects;

public abstract class Subject<TId>(
    bool isBankrupt,
    string name,
    TId id,
    DateTime? bankruptcyDate
    )
    : AggregateRoot<TId>(id) where TId : struct
{
    protected Subject() : this(default!, default!, default!, default!) { } // для EF

    public bool IsBankrupt { get; protected set; } = isBankrupt;
    public string Name { get; protected set; } = name;
    public DateTime? BankruptcyDate { get; protected set; } = bankruptcyDate;
}

//// 1. Самый верхний уровень — чистая техническая база
//public abstract class Entity<TId>
//{
//    public TId Id { get; protected set; }
//    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
//}

//// 2. Средний уровень — Субъекты (те, кто могут владеть чем-то, иметь баланс и т.д.)
//// Обрати внимание: мы всё еще прокидываем <TId> дальше
//public abstract class Subject<TId> : Entity<TId>
//{
//    public decimal Balance { get; protected set; }
//    public string Language { get; protected set; }

//    // Здесь общая логика для всех, у кого есть кошелек
//    public void ChangeBalance(decimal amount) => Balance += amount;
//}

//// 3. Финальный уровень — конкретный Гражданин
//public class Citizen : Subject<CitizenId>
//{
//    public string Name { get; set; }
//    // У Citizen теперь есть и Id (типа CitizenId), и Balance, и CreatedAt
//}