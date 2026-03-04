using EslOnline.SharedKernel.Domain.Enums;
using System;
using System.Diagnostics.CodeAnalysis;

namespace EslOnline.Infrastructure;

public class UnityClipboardReader
{
    public bool TryRead([NotNullWhen(true)] out string text)
    {
        text = UniClipboard.GetText();

        if (string.IsNullOrEmpty(text))
        {
            text = string.Empty;
            return false;
        }

        text = text.Trim();
        return text.Length > 20;
    }
}