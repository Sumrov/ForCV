using System.ComponentModel.DataAnnotations;

namespace EslOnline.Domain.Primitives;

public abstract class Entity<TId>(TId id) where TId : struct
{
    protected Entity() : this(default!) { } // для EF

    public TId Id { get; private set; } = id;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    [Timestamp]
    public byte[]? Timestamp { get; set; }
}
