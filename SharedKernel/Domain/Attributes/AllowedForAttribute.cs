using System;

namespace EslOnline.SharedKernel.Domain.Attributes;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class AllowedForAttribute : Attribute
{
    public AllowedForAttribute(string marker)
    {
        Marker=marker;
    }

    public string Marker { get; }
}
