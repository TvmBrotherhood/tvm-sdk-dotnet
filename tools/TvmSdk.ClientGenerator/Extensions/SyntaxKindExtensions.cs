using Microsoft.CodeAnalysis.CSharp;

namespace TvmSdk.ClientGenerator.Extensions;

public static class SyntaxKindExtensions
{
    public static bool IsKeyword(this SyntaxKind kind)
    {
        return kind is >= SyntaxKind.VoidKeyword and <= SyntaxKind.AsyncKeyword;
    }
}