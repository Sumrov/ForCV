using System.Text.RegularExpressions;
using UnityEditor;

namespace EslOnline.Editor;

public class CSharpVersionSetter : AssetPostprocessor
{
    // Этот метод вызывается каждый раз, когда Unity генерирует файлы проекта
    private static string OnGeneratedCSProject(string path, string content)
    {
        // Заменяем любую версию языка на 10.0
        content = Regex.Replace(content, "<LangVersion>.*?</LangVersion>", "<LangVersion>10.0</LangVersion>");
        return content;
    }
}