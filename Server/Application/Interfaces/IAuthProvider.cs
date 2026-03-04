using EslOnline.SharedKernel.Domain.Enums;

namespace EslOnline.Application.Interfaces;

public interface IAuthProvider
{
    IdentityProvider Provider { get; }
    Task<string> GetAuthorizationUrlAsync();
    Task<string> GetGoogleAccessTokenAsync(string code);
    Task<(string email, string locale, string name, string? picture)> GetGoogleUserinfoAsync(string accessToken);
}
