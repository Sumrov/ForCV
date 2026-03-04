using EslOnline.SharedKernel.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using INotification = EslOnline.SharedKernel.Application.Interfaces.INotification;

namespace EslOnline.SharedKernel.Application;

public static class ApiRegistry
{
    public static readonly Dictionary<string, Type> RequestTypes;
    public static readonly Dictionary<string, Type> ResponseTypes;
    public static readonly Dictionary<string, Type> NotificationTypes;
    public static readonly Dictionary<string, Type> AnonymousRequestTypes;
    public static readonly Dictionary<Type, string> TypeToEndpoint;

    static ApiRegistry()
    {
        var assembly = typeof(ApiRegistry).Assembly;

        RequestTypes = assembly.GetTypes()
            .Where(o => typeof(IBaseRequest).IsAssignableFrom(o) && !o.IsAbstract && !o.IsInterface)
            .ToDictionary(o => o.Name.Replace("Request", ""), o => o);

        ResponseTypes = assembly.GetTypes()
            .Where(o => typeof(IResponse).IsAssignableFrom(o) && !o.IsAbstract && !o.IsInterface)
            .ToDictionary(o => o.Name.Replace("Response", ""), o => o);

        NotificationTypes = assembly.GetTypes()
            .Where(o => typeof(INotification).IsAssignableFrom(o) && !o.IsAbstract && !o.IsInterface)
            .ToDictionary(o => o.Name.Replace("Response", ""), o => o);

        AnonymousRequestTypes = assembly.GetTypes()
            .Where(o => typeof(IAnonymousRequest).IsAssignableFrom(o) && !o.IsAbstract && !o.IsInterface)
            .ToDictionary(o => o.Name.Replace("Request", ""), o => o);

        TypeToEndpoint = RequestTypes.ToDictionary(o => o.Value, o => o.Key);
    }
}