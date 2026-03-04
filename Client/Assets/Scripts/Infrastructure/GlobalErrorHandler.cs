using EslOnline.SharedKernel.Domain.Enums;
using EslOnline.SharedKernel.Domain.Exceptions;
using MessagePipe;
using System;
using UnityEngine;
using VContainer.Unity;

namespace EslOnline.Infrastructure;

public class GlobalErrorHandler : IInitializable, IDisposable
{
    private readonly IPublisher<AppExceptionDto> _errorPublisher;

    public GlobalErrorHandler(IPublisher<AppExceptionDto> errorPublisher)
    {
        _errorPublisher = errorPublisher;
    }

    public void Initialize()
    {
        Application.logMessageReceived += Handle;
    }

    private void Handle(string condition, string stackTrace, LogType type)
    {
        //if (type == LogType.Exception)
        //{
        //    _errorPublisher.Publish(new AppExceptionDto(AppErrorCode.client_error));
        //}

        if (type != LogType.Exception)
        {
            return;
        }
        foreach (AppErrorCode i in Enum.GetValues(typeof(AppErrorCode)))
        {
            if (i == AppErrorCode.client_error)
            {
                continue;
            }
            if (condition.Contains(i.ToString()))
            {
                _errorPublisher.Publish(new AppExceptionDto(i));
                return;
            }
        }
        _errorPublisher.Publish(new AppExceptionDto(AppErrorCode.client_error));
    }

    public void Dispose() => Application.logMessageReceived -= Handle;
}