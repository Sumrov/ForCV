using EslOnline.Domain.Aggregates.Subjects;

namespace EslOnline.Domain.Extensions;

public static class CitizenExtensions
{
    public static float GetProductivity(this Citizen citizen)
    {
        float productivity = 1f;

        // Расчет базовых показателей
        productivity *= citizen.Health / 100f;
        productivity -= citizen.Stress / 2f;
        productivity -= citizen.Hunger;

        // Проверка состояний (эффекты)
        // Если есть алкоголь, продуктивность фиксируется на 0.1
        if (citizen.AlcoholIntoxication != DateTime.MinValue)
            productivity = 0.1f;

        // Наркотики дают буст, перекрывая предыдущие расчеты (согласно твоему коду)
        if (citizen.DrugsIntoxication != DateTime.MinValue)
            productivity = 1.5f;

        // Простуда режет продуктивность пополам
        if (citizen.Cold != DateTime.MinValue)
            productivity *= 0.5f;

        // Травма полностью обнуляет возможность работать
        if (citizen.Injury != DateTime.MinValue)
            productivity = 0f;

        return MathF.Max(0f, productivity);
    }
}
