using EslOnline.SharedKernel.Application.Notifications;
using EslOnline.SharedKernel.Application.Responses;
using EslOnline.SharedKernel.Domain.Enums;
using MessagePipe;
using System;
using System.Text.Json;
using UnityEngine;
using VContainer.Unity;

#nullable enable

namespace EslOnline.Infrastructure;

public class ClipboardMonitor : IDisposable, IInitializable
{
    //private readonly JwtTokenDecoder _decoder;
    private readonly UnityClipboardReader _unityClipboardReader;
    private readonly ISubscriber<GetAuthorizationUrlResponse> _subGetAuthorizationUrl;
    private readonly IPublisher<LoginWithGoogleResponse> _pubLoginWithGoogle;
    private bool _isActive;
    private IDisposable? _disposable;

    public void Dispose()
    {
        Deactivate();
        _disposable?.Dispose();
    }

    public ClipboardMonitor(
        //JwtTokenDecoder decoder,
        UnityClipboardReader unityClipboardReader,
        ISubscriber<GetAuthorizationUrlResponse> subGetAuthorizationUrl,
        IPublisher<LoginWithGoogleResponse> pubLoginWithGoogle
        )
    {
        //_decoder = decoder;
        _unityClipboardReader = unityClipboardReader;
        _subGetAuthorizationUrl = subGetAuthorizationUrl;
        _pubLoginWithGoogle = pubLoginWithGoogle;
    }

    public void Initialize()
    {
        var bag = DisposableBag.CreateBuilder();

        _subGetAuthorizationUrl
            .Subscribe(Handle)
            .AddTo(bag);

        _disposable = bag.Build();
    }

    private void Handle(GetAuthorizationUrlResponse response)
    {
        Activate();
    }

    public void Activate()
    {
        _isActive = true;
        Application.focusChanged += OnFocusChanged;
    }

    public void Deactivate()
    {
        _isActive = false;
        Application.focusChanged -= OnFocusChanged;
    }

    private void OnFocusChanged(bool hasFocus)
    {
        if (!hasFocus || !_isActive) return;

        if (_unityClipboardReader.TryRead(out string rawData))
        {
            try
            {
                LoginWithGoogleResponse? response = JsonSerializer.Deserialize<LoginWithGoogleResponse>(
                    rawData,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (response != null)
                {
                    _pubLoginWithGoogle.Publish(response);
                    Deactivate();
                }
                else
                {
                    Deactivate();
                    throw new Exception(nameof(AppErrorCode.login_google_response_deserialize_error));
                }
            }
            catch
            {
                Deactivate();
                throw new Exception(nameof(AppErrorCode.login_google_response_deserialize_error));
            }
        }
    }
}