using EslOnline.SharedKernel.Domain.Constants;
using EslOnline.SharedKernel.Domain.ValueObjects;
using System.Security.Claims;

namespace EslOnline.Domain.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static CitizenId CitizenId(this ClaimsPrincipal user)
    {
        string? claimValue = user.FindFirst(CustomClaims.CitizenId)?.Value;
        if (string.IsNullOrEmpty(claimValue))
            throw new UnauthorizedAccessException("CitizenId не найден в токене.");
        return new CitizenId(Guid.Parse(claimValue));
    }
}
