using EslOnline.Domain.ValueObjects;

namespace EslOnline.Domain.Interfaces;

public interface IMovable
{
    public int Weight { get; }
    public int Volume { get; }
    public MovableGoodLocation MovebleGoodLocation { get; }
}
