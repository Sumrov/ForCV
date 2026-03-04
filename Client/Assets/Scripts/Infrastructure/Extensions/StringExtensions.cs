namespace EslOnline.Infrastructure.Extensions;

public static class StringExtensions
{
    public static string ToVersionStatus(this string version)
    {
        if (string.IsNullOrEmpty(version)) return "v.unknown";

        // Логика: 0.x.x -> alfa, 1.x.x -> beta
        string prefix = version[0] switch
        {
            '0' => "alpha",
            '1' => "beta",
            _ => "release" // Все остальное (дефолт)
        };
        return $"{prefix} {version}";
    }

    //TMP_text
    //SetBalanceFormatted(this string targetText, string rawValue,
    public static string SetBalanceFormatted(this string rawValue, int totalDigits = 12, string zerosColor = "#C1C1C1")
    {
        //if (targetText == null) return;
        if (string.IsNullOrEmpty(rawValue)) return "v.unknown";

        // 1. Превращаем в число, чтобы убрать лишний мусор, если он есть
        if (!int.TryParse(rawValue, out int value)) value = 0;

        return SetBalanceFormatted(value, totalDigits, zerosColor);
    }

    public static string SetBalanceFormatted(this int rawValue, int totalDigits = 12, string zerosColor = "#C1C1C1")
    {
        // 2. Форматируем число с ведущими нулями (например, "000000000150")
        string digits = rawValue.ToString(new string('0', totalDigits));

        // 3. Разбиваем на группы по 3 пробелами (через регулярку — это быстрее всего пишется)
        // Результат: "000 000 000 150"
        string spaced = System.Text.RegularExpressions.Regex.Replace(digits, ".{3}", "$0 ").Trim();

        // 4. Находим, где заканчиваются "бесполезные" нули
        // Ищем первый символ, который не '0' и не ' ' (пробел)
        int firstActiveDigitIndex = 0;
        for (int i = 0; i < spaced.Length; i++)
        {
            if (spaced[i] != '0' && spaced[i] != ' ')
            {
                firstActiveDigitIndex = i;
                break;
            }
            // Если дошли до конца и все нули, оставим последнюю цифру белой
            if (i == spaced.Length - 1) firstActiveDigitIndex = i;
        }

        // 5. Красим
        string grayPart = spaced[..firstActiveDigitIndex];
        string whitePart = spaced[firstActiveDigitIndex..];

        //targetText.text = $"<color={zerosColor}>{grayPart}</color>{whitePart}";
        return $"<color={zerosColor}>{grayPart}</color>{whitePart}";
    }
}