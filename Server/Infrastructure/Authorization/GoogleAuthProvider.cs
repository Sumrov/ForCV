using EslOnline.Application.Interfaces;
using EslOnline.Domain.Exceptions;
using EslOnline.Infrastructure.Configuration;
using EslOnline.SharedKernel.Domain.Enums;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace EslOnline.Infrastructure.Authorization;

public class GoogleAuthProvider(IHttpClientFactory httpClientFactory, IOptions<GoogleAuthOptions> options) : IAuthProvider
{
    public IdentityProvider Provider => IdentityProvider.Google;
    private readonly GoogleAuthOptions _options = options.Value;
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient();

    public async Task<(string email, string locale, string name, string? picture)> GetGoogleUserinfoAsync(string accessToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        var response = await _httpClient.GetAsync(options.Value.GoogleUserInfoURL);
        var json = await response.Content.ReadFromJsonAsync<JsonElement>();
        if (!json.GetProperty("email_verified").GetBoolean())
            throw new AppException(AppErrorCode.google_email_not_verified);
        //if (json.GetProperty("locale").GetString() == null)
        //    throw new AppException(AppErrorCode.google_locale_missing);
        return (
            json.GetProperty("email").GetString()!,
            //json.GetProperty("locale").GetString()!,
            "",
            json.GetProperty("name").GetString()!,
            json.TryGetProperty("picture", out var pic) ? pic.GetString() : null
        );
    }

    public async Task<string> GetGoogleAccessTokenAsync(string code)
    {
        var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
        { "grant_type", "authorization_code" },
        { "client_id", _options.Google.ClientId },
        { "client_secret", _options.Google.ClientSecret },
        { "code", code },
        { "redirect_uri", _options.GoogleRedirectURL }
        });

        var response = await _httpClient.PostAsync("https://oauth2.googleapis.com/token", content);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadFromJsonAsync<JsonElement>();
        var accessToken = json.GetProperty("access_token").GetString();
        if (string.IsNullOrEmpty(accessToken))
            throw new Exception("Не удалось получить access_token от Google");
        return accessToken;
    }

    public Task<string> GetAuthorizationUrlAsync()
    {
        const string baseUrl = "https://accounts.google.com/o/oauth2/v2/auth";
        var queryParams = new Dictionary<string, string?>
        {
            { "client_id", _options.Google.ClientId },
            { "redirect_uri", _options.GoogleRedirectURL },
            { "response_type", "code" },
            { "scope", "openid email profile" },
        };
        return Task.FromResult(QueryHelpers.AddQueryString(baseUrl, queryParams));
    }
}

