using EslOnline.Domain.Interfaces;

namespace EslOnline.Domain.Primitives;

public abstract class AggregateRoot<TId>(TId id) : Entity<TId>(id) where TId : struct
{
}
