using EslOnline.SharedKernel.Domain.Constants;
using EslOnline.SharedKernel.Domain.Dto;
using System.Security.Claims;

namespace EslOnline.Domain.Extensions;

public static class TokenDataExtensions
{
    public static ClaimsIdentity ToClaimsIdentity(this TokenData dto)
    {
        return new ClaimsIdentity(
        [
            //new Claim(CustomClaims.UserId, dto.UserId),
            new Claim(CustomClaims.CitizenId, dto.CitizenId.Value.ToString()),
            //new Claim(CustomClaims.CitizenName, dto.CitizenName),
            //new Claim(CustomClaims.Citizenship, dto.Citizenship),
            //new Claim(CustomClaims.Language, dto.Language),
            //new Claim(CustomClaims.Balance, dto.Balance)
        ]);
    }
}