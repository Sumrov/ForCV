using System;
using System.Runtime.InteropServices;

namespace EslOnline.Infrastructure;

public static class GuidExtensions
{
    /// <summary>
    /// Максимально быстро преобразует GUID в 8-значный визуальный ID.
    /// Использует первые 4 байта GUID без выделения памяти в куче.
    /// </summary>
    public static string ToFastVisualId(this Guid guid)
    {
        // Интерпретируем память GUID как массив uint и берем первое значение
        // Это быстрее, чем guid.ToByteArray(), так как не создает новый массив
        uint id = MemoryMarshal.Cast<Guid, uint>(MemoryMarshal.CreateReadOnlySpan(ref guid, 1))[0];

        // "X8" гарантирует ровно 8 символов в 16-ричной системе (например, 4A2B1C3D)
        return id.ToString("X8");
    }
}
