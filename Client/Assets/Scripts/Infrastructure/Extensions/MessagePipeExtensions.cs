using MessagePipe;
using System;
using System.Collections.Generic;
using System.Reflection;
using VContainer;

namespace EslOnline.Infrastructure.Extensions;

public static class MessagePipeExtensions
{
    public static void RegisterAllPublishersByTypes(this IContainerBuilder builder, MessagePipeOptions options, IEnumerable<Type> types)
    {
        foreach (var responseType in types)
        {
            typeof(MessagePipeExtensions)
                .GetMethod(nameof(Register), BindingFlags.NonPublic | BindingFlags.Static)!
                .MakeGenericMethod(responseType)
                .Invoke(null, new object[] { builder, options });
        }
    }

    private static void Register<T>(IContainerBuilder builder, MessagePipeOptions options)
    {
        builder.RegisterMessageBroker<T>(options);
    }
}