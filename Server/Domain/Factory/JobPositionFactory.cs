using EslOnline.Domain.ValueObjects;
using EslOnline.SharedKernel.Domain.Constants;
using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.Extensions;
using EslOnline.SharedKernel.Domain.ValueObjects;

namespace EslOnline.Domain.Factory;

public class JobPositionFactory
{
    public JobPosition Create(Position position, GovernmentId governmentId)
    {
        if (!position.IsAllowedFor(AllowedForMarkers.GevernmentJob))
            throw new ApplicationException($"Должность {position} недопустима для правительства");

        return new JobPosition(position, governmentId);
    }

    public JobPosition Create(Position position, CompanyId governmentId)
    {
        if (!position.IsAllowedFor(AllowedForMarkers.CompanyJob))
            throw new ApplicationException($"Должность {position} недопустима для компании");

        return new JobPosition(position, governmentId);
    }
}
