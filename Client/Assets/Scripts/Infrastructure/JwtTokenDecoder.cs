using EslOnline.SharedKernel.Domain.Dto;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using UnityEngine;

#nullable enable

namespace EslOnline.Infrastructure;

public class JwtTokenDecoder
{
    public bool TryDecode(string token, [NotNullWhen(true)] out TokenData? tokenData)
    {
        tokenData = null;

        try
        {
            if (string.IsNullOrEmpty(token)) return false;

            var parts = token.Split('.');
            if (parts.Length < 2) return false;

            string json = AccessTokenFormatToPlainJson(parts[1]);
            tokenData = JsonSerializer.Deserialize<TokenData>(json);

            return tokenData != null;
        }
        catch (Exception ex)
        {
            Debug.LogWarning($"[JwtDecoder] Failed to decode token: {ex.Message}");
            int.TryParse("sd", out var sads);
            return false;
        }
    }

    private static string AccessTokenFormatToPlainJson(string base64UrlPayload)
    {
        string base64 = base64UrlPayload
            .Replace('-', '+')
            .Replace('_', '/');
        int paddingNeeded = (4 - base64.Length % 4) % 4;
        if (paddingNeeded > 0)
        {
            base64 = base64.PadRight(base64.Length + paddingNeeded, '=');
        }
        byte[] bytes = Convert.FromBase64String(base64);
        return Encoding.UTF8.GetString(bytes);
    }
}