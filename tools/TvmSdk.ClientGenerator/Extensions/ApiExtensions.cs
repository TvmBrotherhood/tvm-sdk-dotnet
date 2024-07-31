using System.Text.Json;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TvmSdk.ApiModels;
using TvmSdk.ClientGenerator.Helpers;
using CSharpTypeEnum = TvmSdk.ClientGenerator.Enums.CSharpType;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace TvmSdk.ClientGenerator.Extensions;

public static class ApiExtensions
{
    private static readonly string[] ValueTypes =
    [
        "Value",
        "Value?",
        "Value[]"
    ];

    public static string? CSharpType(this ApiModelProperty property, string moduleName)
    {
        return property switch
        {
            ApiModelProperty.String =>
                CSharpTypeEnum.String.ToString().ToLowerInvariant(),
            ApiModelProperty.Boolean =>
                CSharpTypeEnum.Bool.ToString().ToLowerInvariant(),

            ApiModelProperty.Number { NumberType: ApiNumberType.Float, NumberSize: 64 } =>
                CSharpTypeEnum.Double.ToString().ToLowerInvariant(),
            ApiModelProperty.Number { NumberType: ApiNumberType.Float, NumberSize: 32 } =>
                CSharpTypeEnum.Float.ToString().ToLowerInvariant(),
            ApiModelProperty.Number { NumberType: ApiNumberType.Float } =>
                CSharpTypeEnum.Float.ToString().ToLowerInvariant(),

            ApiModelProperty.Number { NumberType: ApiNumberType.UInt, NumberSize: 64 } =>
                CSharpTypeEnum.ULong.ToString().ToLowerInvariant(),
            ApiModelProperty.Number { NumberType: ApiNumberType.UInt, NumberSize: 32 } =>
                CSharpTypeEnum.UInt.ToString().ToLowerInvariant(),
            ApiModelProperty.Number { NumberType: ApiNumberType.UInt, NumberSize: 16 } =>
                CSharpTypeEnum.UShort.ToString().ToLowerInvariant(),
            ApiModelProperty.Number { NumberType: ApiNumberType.UInt, NumberSize: 8 } =>
                CSharpTypeEnum.Byte.ToString().ToLowerInvariant(),
            ApiModelProperty.Number { NumberType: ApiNumberType.UInt } =>
                CSharpTypeEnum.UInt.ToString().ToLowerInvariant(),

            ApiModelProperty.Number { NumberType: ApiNumberType.Int, NumberSize: 64 } =>
                CSharpTypeEnum.Long.ToString().ToLowerInvariant(),
            ApiModelProperty.Number { NumberType: ApiNumberType.Int, NumberSize: 32 } =>
                CSharpTypeEnum.Int.ToString().ToLowerInvariant(),
            ApiModelProperty.Number { NumberType: ApiNumberType.Int, NumberSize: 16 } =>
                CSharpTypeEnum.Short.ToString().ToLowerInvariant(),
            ApiModelProperty.Number { NumberType: ApiNumberType.Int, NumberSize: 8 } =>
                CSharpTypeEnum.SByte.ToString().ToLowerInvariant(),
            ApiModelProperty.Number { NumberType: ApiNumberType.Int } =>
                CSharpTypeEnum.Int.ToString().ToLowerInvariant(),

            ApiModelProperty.BigInt { NumberType: ApiNumberType.UInt, NumberSize: 64 } =>
                CSharpTypeEnum.ULong.ToString().ToLowerInvariant(),

            ApiModelProperty.Array arr =>
                arr.ArrayItem.CSharpType(moduleName) + "[]",
            ApiModelProperty.Ref @ref =>
                MapRefType(@ref.RefName, moduleName),
            ApiModelProperty.Optional optional =>
                optional.OptionalInner.CSharpType(moduleName) == null
                    ? throw new NotImplementedException()
                    : optional.OptionalInner.CSharpType(moduleName)!.EndsWith('?')
                        ? optional.OptionalInner.CSharpType(moduleName)
                        : optional.OptionalInner.CSharpType(moduleName) + "?",
            ApiModelProperty.None => null,
            ApiModelProperty.Generic { GenericArgs.Length: 1 } generic =>
                generic.GenericArgs[0].CSharpType(moduleName),
            _ => throw new ArgumentOutOfRangeException(
                nameof(property),
                property,
                $"Type {property.GetType().Name} is not implemented (Name: {property.Name}).")
        };
    }

    public static string ToSafeCSharpName(this ApiBaseTypeInfo baseTypeInfo)
    {
        return baseTypeInfo.Name.ToCamelCase().ToSafeCSharpString();
    }

    public static bool IsParam(this ApiModel model)
    {
        return model.Name.StartsWith("ParamsOf");
    }

    public static bool IsResult(this ApiModel model)
    {
        return model.Name.StartsWith("ResultOf");
    }

    public static MemberDeclarationSyntax[] GetProperties(this ApiEnumType enumType, string moduleName)
    {
        return enumType switch
        {
            ApiEnumType.Struct @struct => @struct.StructFields
                .Select(property => Property(
                    property.Name,
                    property.CSharpType(moduleName)!,
                    property.Summary,
                    property.Description,
                    @struct.Name
                ))
                .ToArray(),
            ApiEnumType.Ref @ref =>
            [
                Property(
                    @ref.Name,
                    MapRefType(@ref.RefName, moduleName),
                    @ref.Summary,
                    @ref.Description,
                    enumType.Name)
            ],
            _ => throw new ArgumentOutOfRangeException(nameof(enumType), enumType, null)
        };
    }

    public static MemberDeclarationSyntax[] GetProperties(this ApiModel.Struct @struct, string moduleName)
    {
        return @struct.StructFields
            .Select(property => Property(
                property.Name,
                property.CSharpType(moduleName)!,
                property.Summary,
                property.Description,
                @struct.Name
            ))
            .ToArray();
    }
    
    
    public static MethodDeclarationSyntax Method(this ApiFunction function, string moduleName, bool withBody = true)
    {
        var resultOfFunction = function.Result.CSharpType(moduleName);
        var returnType = $"Task{(resultOfFunction != null ? $"<{resultOfFunction}>" : string.Empty)}";
        var method = MethodDeclaration(
                ParseTypeName(returnType),
                function.Name.ToPascalCase())
            .AddParameterListParameters(
                function.Params(moduleName));

        method = withBody
            ? method.Public().WithBody(Block(function.MethodStatement(moduleName)))
            : method.WithSemicolonToken(
                Token(SyntaxKind.SemicolonToken));

        return method
            .WithLeadingTrivia(CarriageReturn, CarriageReturn)
            .AddSummary(function.Summary)
            .AddRemarks(function.Description);
    }
    
    public static StatementSyntax MethodStatement(this ApiFunction function, string moduleName)
    {
        const string clientVariableName = "client";
        const string clientMethodName = "CallFunction";
        var result = function.Result.CSharpType(moduleName);
        var clientInvocation = result == null
            ? MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                IdentifierName(clientVariableName),
                IdentifierName(clientMethodName))
            : MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                IdentifierName(clientVariableName),
                GenericName("CallFunction")
                    .WithTypeArgumentList(
                        TypeArgumentList(
                            SingletonSeparatedList<TypeSyntax>(
                                IdentifierName(result)))));
        var methodExpression = InvocationExpression(clientInvocation)
            .WithArgumentList(
                ArgumentList(
                    SeparatedList(function.Params
                        .Where(x =>
                            x is not ApiModelProperty
                                .Generic) // TODO: Review if you can handle this filter in other way and why this 'Generic is needed after all?
                        .Select(param =>
                            Argument(
                                IdentifierName(param.ToSafeCSharpName())
                            )
                        )
                        .ToList()
                        .Prepend(Argument(
                            LiteralExpression(
                                SyntaxKind.StringLiteralExpression,
                                Literal($"{moduleName.ToLowerInvariant()}.{function.Name}"))))
                    )
                )
            );

        return ReturnStatement(methodExpression);
    }
    
    public static ParameterSyntax[] Params(this ApiFunction function, string moduleName)
    {
        return function.Params
            .Where(x => x is not ApiModelProperty
                .Generic) // TODO: Review if you can handle this filter in other way and why this 'Generic is needed after all?
            .Select(param =>
                Parameter(Identifier(param.ToSafeCSharpName()))
                    .WithType(
                        IdentifierName(param.CSharpType(moduleName)!)))
            .ToArray();
    }

    private static MemberDeclarationSyntax Property(
        string name,
        string cSharpType,
        string? summary,
        string? remarks,
        string parentName)
    {
        var pascalCasedName = name.ToPascalCase();
        var newName = pascalCasedName;

        if (pascalCasedName == parentName)
            newName += "Value";

        var prop = Syntax.Declaration.Member
            .Property(
                cSharpType,
                newName)
            .Public()
            .AddAttributeLists(
                AttributeList(
                    SingletonSeparatedList(
                        Attribute(
                                IdentifierName("JsonPropertyName"))
                            .WithArgumentList(
                                AttributeArgumentList(
                                    SingletonSeparatedList(
                                        AttributeArgument(
                                            LiteralExpression(
                                                SyntaxKind.StringLiteralExpression,
                                                Literal(name)))))))))
            .WithLeadingTrivia(ElasticCarriageReturnLineFeed, ElasticCarriageReturnLineFeed)
            .AddSummary(summary)
            .AddRemarks(remarks) as MemberDeclarationSyntax;

        // TODO: check maybe better always specify attribute "JsonPropertyName" for faster parsing
        //if (pascalCasedName == parentName)
        // prop = prop.AddAttributeLists(
        //     AttributeList(
        //         SingletonSeparatedList(
        //             Attribute(
        //                     IdentifierName("JsonPropertyName"))
        //                 .WithArgumentList(
        //                     AttributeArgumentList(
        //                         SingletonSeparatedList(
        //                             AttributeArgument(
        //                                 LiteralExpression(
        //                                     SyntaxKind.StringLiteralExpression,
        //                                     Literal(name)))))))));
        // prop = prop.AddAttribute(
        //     "JsonPropertyName",
        //     ("name", name, SyntaxKind.NameColon));

        return prop;
    }

    private static string MapRefType(string refName, string moduleName)
    {
        // Check if type is reference to a module specific type
        var splitted = refName.Split('.');

        if (splitted.Length > 2) throw new NotSupportedException();

        if (splitted.Length == 2)
        {
            var refModuleName = splitted[0];
            var typeRef = splitted[1];

            // If module reference is the same then this indication is redundant.
            if (string.Equals(refModuleName, moduleName, StringComparison.OrdinalIgnoreCase))
                refName = typeRef;
        }

        if (refName.EndsWith("Handle")) // TODO: Map to real type
            return CSharpTypeEnum.UInt.ToString().ToLowerInvariant();

        if (ValueTypes.Contains(refName))
            return refName.Replace("Value", nameof(JsonElement));

        return refName.ToPascalCase();
    }
}