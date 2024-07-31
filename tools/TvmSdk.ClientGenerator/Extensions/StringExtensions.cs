using TvmSdk.ClientGenerator.Utils;

namespace TvmSdk.ClientGenerator.Extensions;

public static class StringExtensions
{
    public static string ToSafeCSharpString(this string text)
    {
        return CSharpLangUtil.IsKeyword(text)
            ? $"@{text}"
            : text;
    }

    public static string ToCamelCase(this string text)
    {
        var pascalCased = text.ToPascalCase();

        return string.Concat(
            pascalCased[..1].ToLowerInvariant(),
            pascalCased.AsSpan(1));
    }

    public static string ToPascalCase(this string text)
    {
        text = text.Replace(" ", string.Empty);

        return text.Contains('_')
            ? Thread.CurrentThread.CurrentCulture.TextInfo
                .ToTitleCase(text.Replace("_", " "))
                .Replace(" ", string.Empty)
            : string.Concat(text[..1].ToUpperInvariant(), text.AsSpan(1));
    }
}