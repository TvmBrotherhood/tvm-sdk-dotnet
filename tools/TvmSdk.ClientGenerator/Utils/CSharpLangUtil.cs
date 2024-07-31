using Microsoft.CodeAnalysis.CSharp;
using TvmSdk.ClientGenerator.Extensions;

namespace TvmSdk.ClientGenerator.Utils;

public static class CSharpLangUtil
{
    public static bool IsKeyword(string text)
    {
        var reservedKeywords = Enum.GetValues(typeof(SyntaxKind))
            .Cast<SyntaxKind>()
            .Where(kind => kind.IsKeyword())
            .Select(x => x
                .ToString()
                .Replace("Keyword", "")
                .ToLowerInvariant());

        return reservedKeywords.Contains(text);
    }
}