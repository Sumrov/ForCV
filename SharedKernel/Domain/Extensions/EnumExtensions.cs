using EslOnline.SharedKernel.Domain.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EslOnline.SharedKernel.Domain.Extensions;

public static class EnumExtensions
{
    private static readonly ConcurrentDictionary<(Type, string), HashSet<object>> _cache = new();

    public static bool IsAllowedFor<TEnum>(this TEnum value, string marker) where TEnum : Enum
    {
        var key = (typeof(TEnum), marker);

        var allowed = _cache.GetOrAdd(key, _ =>
            typeof(TEnum)
                .GetFields()
                .Where(f => f.GetCustomAttributes<AllowedForAttribute>()
                    .Any(a => a.Marker == marker))
                .Select(f => f.GetValue(null)!)
                .ToHashSet()
        );

        return allowed.Contains(value);
    }
}
