using Cysharp.Threading.Tasks;
using EslOnline.Infrastructure.Repositories;
using EslOnline.SharedKernel.Application;
using EslOnline.SharedKernel.Domain.Enums;
using System;
using System.Net.Http;
using System.Text.Json;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Networking;

#nullable enable

namespace EslOnline.Infrastructure;

public class UnityHttpClient
{
    private readonly InMemoryRepository _cache;
    private readonly JsonSerializerOptions _jsonOptions;

    public UnityHttpClient(InMemoryRepository cache)
    {
        _cache=cache;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async UniTask<(byte[] Data, int StatusCode)> SendAsync(string url, HttpMethod method, object? payload = null)
    {
        using var request = new UnityWebRequest(url, method.Method);

        if (payload != null)
        {
            byte[] bodyRaw = JsonSerializer.SerializeToUtf8Bytes(payload, _jsonOptions);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);

            if (!ApiRegistry.AnonymousRequestTypes.ContainsValue(payload.GetType()))
            {
                if (_cache.IsAuthorized)
                {
                    request.SetRequestHeader("Authorization", $"Bearer {_cache.AccessToken}");
                }
                else
                {
                    Debug.LogWarning($"[HttpClient] Attempting to send authorized request {payload.GetType().Name} without token!");
                }
            }
        }

        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        try
        {
            await request.SendWebRequest().ToUniTask();
            return (request.downloadHandler.data, (int)request.responseCode);
        }
        //catch (UnityWebRequestException e) // Специальное исключение UniTask
        //{
        //    Debug.LogError($"[HttpClient] Код ответа: {e.ResponseCode}");
        //    Debug.LogError($"[HttpClient] Текст ошибки: {e.Text}"); // Тут будет написано, почему 401
        //    Debug.LogError($"[HttpClient] Error: {e.Error}");
        //    throw; // Прокидываем дальше, чтобы видеть в консоли
        //}
        catch
        {
            //Debug.LogError($"[HttpClient] критическая ошибка: {e.Message}");
            //return (Array.Empty<byte>(), 0);
            throw new Exception(nameof(AppErrorCode.network_error));
        }
    }
}