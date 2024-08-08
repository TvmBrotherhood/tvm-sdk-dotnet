using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Formatting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TvmSdk.ClientGenerator.Enums;
using TvmSdk.ClientGenerator.Helpers;
using TvmSdk.ClientGenerator.Models;
using TvmSdk.ClientGenerator.Utils;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Formatter = Microsoft.CodeAnalysis.Formatting.Formatter;

namespace TvmSdk.ClientGenerator.Extensions;

public static partial class SyntaxExtensions
{
    public static T Public<T>(this T @enum) where T : MemberDeclarationSyntax
    {
        return (T)@enum.AddModifiers(Token(SyntaxKind
            .PublicKeyword));
    }

    public static T Abstract<T>(this T member) where T : MemberDeclarationSyntax
    {
        return (T)member.AddModifiers(Token(SyntaxKind.AbstractKeyword));
    }

    public static void WriteTo(this CompilationUnitSyntax @this, string filePath)
    {
        using var file = new FileWriter(filePath);
        @this.Format().WriteTo(file.StreamWriter);
    }

    public static CompilationUnitSyntax ToCompilationUnit<T>(this T @this)
        where T : MemberDeclarationSyntax
    {
        return CompilationUnit().AddMembers(@this);
    }

    public static T AddAttribute<T>(
        this T @this,
        string name,
        params (string Name, string Value)[] args)
        where T : MemberDeclarationSyntax
    {
        return (T)@this.AddAttribute(
            name,
            args.Select(arg =>
                    (arg.Name, arg.Value, default(SyntaxKind?)))
                .ToArray());
    }

    public static T AddAttribute<T>(
        this T @this,
        string name,
        params (string Name, string Value, SyntaxKind? Kind)[] args)
        where T : MemberDeclarationSyntax
    {
        // Create the named argument syntax
        var attributeArguments = args
            .Select(arg =>
                arg.Kind switch
                {
                    SyntaxKind.TypeOfKeyword => AttributeArgument(
                        TypeOfExpression(
                            IdentifierName(arg.Name))),
                    SyntaxKind.NameColon => AttributeArgument(
                        default,
                        NameColon(arg.Name),
                        LiteralExpression(
                            SyntaxKind.StringLiteralExpression,
                            Literal(arg.Value))),
                    null => AttributeArgument(
                        NameEquals(arg.Name),
                        default,
                        LiteralExpression(
                            SyntaxKind.StringLiteralExpression,
                            Literal(arg.Value))),
                    _ => throw new NotImplementedException()
                }
            );

        // Create the argument list syntax
        var argumentList = AttributeArgumentList(
            SeparatedList(attributeArguments));

        // Create the attribute syntax with the named argument
        var attribute = Attribute(
            IdentifierName(name),
            argumentList);

        // Create the attribute list syntax
        var attributeList = AttributeList(
            SingletonSeparatedList(attribute));

        return (T)@this.AddAttributeLists(attributeList);
    }

    public static EnumDeclarationSyntax AddType(this EnumDeclarationSyntax @enum, IEnumerable<long?> values)
    {
        long min = 0;
        long max = 0;

        foreach (var value in values)
            if (value is null)
                max++;
            else if (value < min)
                min = value.Value;
            else if (value > max)
                max = value.Value;

        @enum = min switch
        {
            >= byte.MinValue when max <= byte.MaxValue => @enum.SetType(CSharpType.Byte),
            >= sbyte.MinValue when max <= sbyte.MaxValue => @enum.SetType(CSharpType.SByte),
            >= short.MinValue when max <= short.MaxValue => @enum.SetType(CSharpType.Short),
            >= ushort.MinValue when max <= ushort.MaxValue => @enum.SetType(CSharpType.UShort),
            >= int.MinValue when max <= int.MaxValue => @enum.SetType(CSharpType.Int),
            >= uint.MinValue when max <= uint.MaxValue => @enum.SetType(CSharpType.UInt),
            _ => throw new NotImplementedException()
        };

        return @enum;
    }

    public static SyntaxNode Format(this CSharpSyntaxNode @this)
    {
        var workspace = new AdhocWorkspace();
        workspace.Options.WithChangedOption(CSharpFormattingOptions.IndentBlock, true);

        var formattedNode = Formatter.Format(@this, workspace, workspace.Options);

        return formattedNode;
    }

    public static EnumDeclarationSyntax AddProperties(
        this EnumDeclarationSyntax @enum,
        IReadOnlyCollection<EnumInfo> properties)
    {
        var result = @enum
            .AddMembers(properties
                .Select(property =>
                {
                    var enumMember = Syntax.Declaration.Member.Enum(property.Name.ToPascalCase())
                        .AddSummary(property.Summary)
                        .AddRemarks(property.Remarks);

                    if (property.Value is not null)
                        enumMember = enumMember
                            .EqualsValue(property.Value.Value);

                    return enumMember;
                })
                .ToArray());
        
        return result;
    }

    public static NamespaceDeclarationSyntax AddNamespace(this MemberDeclarationSyntax @this, string @namespace)
    {
        return NamespaceDeclaration(IdentifierName(@namespace))
            .AddMembers(@this);
    }

    public static FileScopedNamespaceDeclarationSyntax ToFileScopedNamespace(this MemberDeclarationSyntax @this,
        string @namespace)
    {
        return FileScopedNamespaceDeclaration(IdentifierName(@namespace))
            .AddMembers(@this);
    }

    public static CompilationUnitSyntax AddUsings(this CompilationUnitSyntax compilationUnitSyntax, string usingsLine)
    {
        return compilationUnitSyntax
            .AddUsings(UsingDirective(
                ParseName(usingsLine)));
    }
    
    public static EnumMemberDeclarationSyntax EqualsValue(this EnumMemberDeclarationSyntax enumMember, int value)
    {
        return enumMember
            .WithEqualsValue(
                EqualsValueClause(
                    LiteralExpression(
                        SyntaxKind.NumericLiteralExpression,
                        Literal(value))));
    }

    private static EnumDeclarationSyntax SetType(this EnumDeclarationSyntax @enum, string type)
    {
        return @enum.AddBaseListTypes(SimpleBaseType(IdentifierName(type)));
    }

    private static EnumDeclarationSyntax SetType(this EnumDeclarationSyntax @enum, CSharpType type)
    {
        return @enum.SetType(type.ToString().ToLowerInvariant());
    }
}