using Cysharp.Threading.Tasks;
using EslOnline.Infrastructure.ScriptableObjects;
using EslOnline.SharedKernel.Application;
using EslOnline.SharedKernel.Application.Interfaces;
using EslOnline.SharedKernel.Application.Notifications;
using EslOnline.SharedKernel.Domain.Constants;
using EslOnline.SharedKernel.Domain.Exceptions;
using MediatR;
using MessagePipe;
using System;
using System.Net.Http;
using System.Text.Json;

namespace EslOnline.Infrastructure;

public class NetworkService
{
    private readonly UnityHttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly ClientSettingSO _settingSO;
    private readonly IServiceProvider _serviceProvider;
    //private readonly IPublisher<AppExceptionDto> _pubAppException;
    private readonly IPublisher<NetworkActivityNotification> _pubNetworkActivity;
    private int _activeRequests = 0;

    public NetworkService(
        UnityHttpClient httpClient,
        ClientSettingSO settingSO,
        IServiceProvider serviceProvider,
        //IPublisher<AppExceptionDto> pubAppException,
        IPublisher<NetworkActivityNotification> pubNetworkActivity)
    {
        _httpClient = httpClient;
        _settingSO = settingSO;
        _serviceProvider =serviceProvider;
        //_pubAppException=pubAppException;
        _pubNetworkActivity=pubNetworkActivity;

        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async UniTask SendAsync<TResponse>(IRequest<TResponse> request)
    {
        try
        {
            _activeRequests++;
            _pubNetworkActivity.Publish(new NetworkActivityNotification(true));

            var requestType = request.GetType();
            var endpoint = ApiRegistry.TypeToEndpoint[requestType];
            var isAnonymous = request is IAnonymousRequest;
            var baseUrl = isAnonymous ? Routes.Anonymous : Routes.Authorization;
            var fullUrl = _settingSO.HostBaseUrl + baseUrl + endpoint;

            var (rawData, statusCode) = await _httpClient.SendAsync(fullUrl, HttpMethod.Post, request);
            var json = System.Text.Encoding.UTF8.GetString(rawData);

            if (statusCode == 200)
            {
                var response = JsonSerializer.Deserialize<TResponse>(json, _jsonOptions);
                var publisher = _serviceProvider.GetRequiredService<IPublisher<TResponse>>();
                publisher.Publish(response);
            }
            //else if (statusCode == 0)
            //{
            //    _pubAppException.Publish(new AppExceptionDto(AppErrorCode.network_error));
            //}
            else
            {
                var error = JsonSerializer.Deserialize<AppExceptionDto>(json, _jsonOptions);
                throw new Exception(nameof(error.ErrorCode));
                //_pubAppException.Publish(error);
            }
        }
        finally
        {
            _activeRequests--;
            if (_activeRequests <= 0)
            {
                _activeRequests = 0;
                _pubNetworkActivity.Publish(new NetworkActivityNotification(false));
            }
        }
    }
}