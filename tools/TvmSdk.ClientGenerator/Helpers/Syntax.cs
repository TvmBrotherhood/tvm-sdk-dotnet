using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace TvmSdk.ClientGenerator.Helpers;

public static class Syntax
{
    public static class Declaration
    {
        public static EnumDeclarationSyntax Enum(string name)
        {
            return EnumDeclaration(name);
        }

        public static StructDeclarationSyntax Struct(string name)
        {
            return StructDeclaration(name);
        }

        public static ClassDeclarationSyntax Class(string name)
        {
            return ClassDeclaration(name);
        }

        public static RecordDeclarationSyntax Record(string name)
        {
            return RecordDeclaration(
                    Token(SyntaxKind.RecordKeyword),
                    name)
                .WithOpenBraceToken(Token(SyntaxKind.OpenBraceToken))
                .WithCloseBraceToken(Token(SyntaxKind.CloseBraceToken));
        }

        public static InterfaceDeclarationSyntax Interface(string name)
        {
            return InterfaceDeclaration(name);
        }

        public static class Member
        {
            public static EnumMemberDeclarationSyntax Enum(string name)
            {
                return EnumMemberDeclaration(name);
            }

            public static PropertyDeclarationSyntax Property(string type, string name)
            {
                return PropertyDeclaration(IdentifierName(type), name)
                    .WithAccessorList(
                        AccessorList(
                            List(new[]
                            {
                                AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                    .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)),
                                AccessorDeclaration(SyntaxKind.InitAccessorDeclaration)
                                    .WithSemicolonToken(Token(SyntaxKind.SemicolonToken))
                            })));
            }
        }
    }
}