using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.ValueObjects;

public record JobPosition(
    Position Position,
    SubjectId SubjectId
    )
{
    protected JobPosition() : this(default!, default!) { }

    internal static JobPosition Create(
        Position Position,
        SubjectId SubjectId
        )
    {
        return new JobPosition(
            Position: Position,
            SubjectId: SubjectId
            );
    }
};
