using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TvmSdk.ApiModels;
using TvmSdk.ClientGenerator.Extensions;
using TvmSdk.ClientGenerator.Helpers;
using TvmSdk.ClientGenerator.Models;
using TvmSdk.ClientGenerator.Utils;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace TvmSdk.ClientGenerator;

internal abstract class Program
{
    private static async Task Main(string[] args)
    {
        var currentPath = AppDomain.CurrentDomain.BaseDirectory;
        var projectName = $"TvmSdk";
        var apiFilePath = "api.json";

        args = args
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToArray();
        if (args.Length == 3)
        {
            if (!string.IsNullOrWhiteSpace(args[0]))
                currentPath = args[0];

            if (!string.IsNullOrWhiteSpace(args[1]))
                projectName = args[1];

            if (!string.IsNullOrWhiteSpace(args[2]))
                apiFilePath = args[2];
        }
        Console.WriteLine($"Generating client '{projectName}' from '{apiFilePath}', please wait.");
        
        var projectPath = Path.Combine(currentPath, $"../../src/clients/");
        var outputPath = $"{projectPath}/{projectName}/Modules";
        var everApi = await JsonUtil.DeserializeFile<API>(apiFilePath);

        if (Directory.Exists(outputPath))
            Directory.Delete(outputPath, true);
        
        
        var clientName = projectName;
        var projectNameSplitted = projectName.Split('.');

        if (projectNameSplitted.Length == 2)
            clientName = projectNameSplitted[1];

        clientName = $"{clientName}Client";
        var client = Syntax.Declaration
            .Class(clientName)
            .Public()
            .AddBaseListTypes(SimpleBaseType(IdentifierName($"I{clientName}")));
        
        // Create a new constructor with parameters
        var ctor = ConstructorDeclaration(Identifier(clientName))
            .Public()
            .AddParameterListParameters(
                Parameter(Identifier("adapter"))
                    .WithType(ParseTypeName("ITvmSdkDllAdapter")));
            
        everApi.Modules
            .ToList()
            .ForEach(module =>
            {
                ctor = ctor
                    .AddParameterListParameters(
                        Parameter(Identifier($"{module.Name}Module"))
                            .WithType(NullableType(ParseTypeName($"I{module.Name.ToPascalCase()}Module")))
                            .WithDefault(EqualsValueClause(LiteralExpression(SyntaxKind.NullLiteralExpression)))
                    );
            });

        var assignments = everApi.Modules
            .Select(module => 
                ExpressionStatement(
                    AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        IdentifierName(module.Name.ToPascalCase()),
                        BinaryExpression(
                            SyntaxKind.CoalesceExpression,
                            IdentifierName($"{module.Name}Module"),
                            ObjectCreationExpression(
                                IdentifierName($"{module.Name.ToPascalCase()}Module"))
                                .WithArgumentList(
                                    ArgumentList(
                                        SeparatedList<ArgumentSyntax>(
                                            new[]
                                            {
                                                Argument(IdentifierName("adapter"))
                                            })))))) as StatementSyntax)
            .ToArray();
        
        ctor = ctor
            .AddBodyStatements(assignments);
        
        // // Create a nullable context directive
        // var nullableDirective = Trivia(PreprocessorDirectiveTrivia(
        //     Token(SyntaxKind.HashToken),
        //     Token(SyntaxKind.NullableKeyword),
        //     Token(SyntaxKind.EnableKeyword),
        //     Token(SyntaxKind.EndOfLineTrivia),
        //     isActive: true
        // ));
        
        var clientCompilationUnit = client
            .AddMembers(everApi.Modules
                .Select(module =>
                    Syntax.Declaration.Member
                        .Property(
                            $"I{module.Name.ToPascalCase()}Module",
                            module.Name.ToPascalCase())
                        .Public() as MemberDeclarationSyntax
                )
                .ToArray())
            .AddMembers(ctor)
            .ToFileScopedNamespace(projectName)
            .ToCompilationUnit()
            .AddUsings("TvmSdk.DllAdapter");
        
        everApi.Modules
            .ToList()
            .ForEach(module =>
            {
                clientCompilationUnit = clientCompilationUnit
                    .AddUsings($"{projectName}.Modules.{module.Name.ToPascalCase()}");
            });
        
        clientCompilationUnit
            .WriteTo($"{projectPath}/{projectName}/{clientName}.Generated.cs");
        
        // Interface
        
        var interfaceCompilationUnit = Syntax.Declaration
            .Interface($"I{clientName}")
            .Public()
            // .AddSummary(module.Summary)
            // .AddRemarks(module.Description)
            .AddMembers(everApi.Modules
                .Select(module =>
                    Syntax.Declaration.Member
                        .Property(
                            $"I{module.Name.ToPascalCase()}Module",
                            module.Name.ToPascalCase())as MemberDeclarationSyntax
                )
                .ToArray())
            .ToFileScopedNamespace(projectName)
            .ToCompilationUnit();
            
        everApi.Modules
            .ToList()
            .ForEach(module =>
            {
                interfaceCompilationUnit = interfaceCompilationUnit
                    .AddUsings($"{projectName}.Modules.{module.Name.ToPascalCase()}");
            });
            
        interfaceCompilationUnit.WriteTo($"{projectPath}/{projectName}/I{clientName}.Generated.cs");

        
        
        var typeNamespaceLookup = everApi.Modules
            .SelectMany(module =>
                module.Types
                    .Select(type =>
                        (ModuleName: module.Name.ToPascalCase(), Type: type!)))
            .ToDictionary(
                x => x.Type.Name,
                x =>
                {
                    var @namespace = new List<string> { projectName, "Modules", x.ModuleName };

                    if (x.Type is ApiModel.EnumOfConsts)
                        @namespace.Add("Enums");
                    else if (x.Type.IsParam())
                        @namespace.AddRange(["Models", "Params"]);
                    else if (x.Type.IsResult())
                        @namespace.AddRange(["Models", "Results"]);
                    else
                        @namespace.Add("Models");

                    // TODO: Move only params and client module to main namespace?

                    return (
                        Namespace: string.Join('.', @namespace)
                            .Replace(".Enums", "")
                            .Replace(".Models", "")
                            .Replace(".Params", "")
                            .Replace(".Results", ""), // (!!!) Temporary fix for refernces
                        Filepath: $"{projectPath}/{string.Join('/', @namespace)}/{x.Type.Name}.Generated.cs"
                    );
                });

        foreach (var module in everApi.Modules)
        {
            module.Types
                .Where(t => t is ApiModel.EnumOfConsts)
                .Cast<ApiModel.EnumOfConsts>()
                .ToList()
                .ForEach(GenerateEnum);

            module.Types
                .Where(x => x is ApiModel.Struct)
                .Cast<ApiModel.Struct>()
                .ToList()
                .ForEach(GenerateRecord(module));

            module.Types
                .Where(t => t is ApiModel.EnumOfTypes)
                .Cast<ApiModel.EnumOfTypes>()
                .ToList()
                .ForEach(GeneratePolymorphicRecord(module));

            GenerateModuleInterface(module);
            GenerateModuleClass(module);
        }
        
        Console.WriteLine("Done!");

        return;

        void GenerateEnum(ApiModel.EnumOfConsts model)
        {
            var typeNamespace = typeNamespaceLookup[model.Name];
            using var file = new FileWriter(typeNamespace.Filepath);

            var isNumberEnum = model.EnumConsts.All(x => x is ApiEnumConst.Number);
            var @enum = Syntax.Declaration
                .Enum(model.Name)
                .Public()
                .AddSummary(model.Summary)
                .AddRemarks(model.Description)
                .AddType(model.EnumConsts
                    .Select(x =>
                        x is ApiEnumConst.Number number
                            ? number.Value
                            : default(long?)))
                .AddProperties(model.EnumConsts
                    .Select(x => new EnumInfo
                    {
                        Name = x.Name,
                        Value = x is ApiEnumConst.Number number ? (int)number.Value : default(int?),
                        Summary = x.Summary,
                        Remarks = x.Description
                    })
                    .ToList());

            if (!isNumberEnum)
            {
                @enum = @enum
                    .AddAttribute("JsonConverter",
                        ("JsonStringEnumConverter", "", SyntaxKind.TypeOfKeyword));
            }
                    
            @enum
                .ToFileScopedNamespace(typeNamespace.Namespace)
                .ToCompilationUnit()
                .Format()
                .WriteTo(file.StreamWriter);
        }

        Action<ApiModel.Struct> GenerateRecord(ApiModule module)
        {
            return model =>
            {
                var typeNamespace = typeNamespaceLookup[model.Name];
                using var file = new FileWriter(typeNamespace.Filepath);

                Syntax.Declaration
                    .Record(model.Name)
                    .AddMembers(model.GetProperties(module.Name))
                    .Public()
                    .AddSummary(model.Summary)
                    .AddRemarks(model.Description)
                    .ToFileScopedNamespace(typeNamespace.Namespace)
                    .Format()
                    .WriteTo(file.StreamWriter);
            };
        }

        Action<ApiModel.EnumOfTypes> GeneratePolymorphicRecord(ApiModule apiModule)
        {
            return model =>
            {
                var compilationUnit = CompilationUnit();
                var typeNamespace = typeNamespaceLookup[model.Name];
                using var file = new FileWriter(typeNamespace.Filepath);

                var derivedTypes = model.EnumTypes
                    .Select(enumType =>
                    {
                        MemberDeclarationSyntax result = Syntax.Declaration
                            .Record(enumType.Name)
                            .Public()
                            .AddMembers(enumType.GetProperties(apiModule.Name))
                            .AddBaseListTypes(SimpleBaseType(IdentifierName(model.Name)))
                            .AddSummary(enumType.Summary)
                            .AddRemarks(enumType.Description);

                        return result;
                    })
                    .ToArray();
                var polymorphic = Syntax.Declaration.Record(model.Name)
                    .AddMembers(derivedTypes)
                    .Public()
                    .Abstract()
                    .AddSummary(model.Summary)
                    .AddRemarks(model.Description)
                    .AddAttribute(
                        "JsonPolymorphic",
                        ("TypeDiscriminatorPropertyName", "type"));

                model.EnumTypes.ToList().ForEach(enumType =>
                {
                    polymorphic = polymorphic.AddAttribute(
                        "JsonDerivedType",
                        (enumType.Name, "", SyntaxKind.TypeOfKeyword),
                        ("typeDiscriminator", enumType.Name, SyntaxKind.NameColon)
                    );
                });

                polymorphic
                    .ToFileScopedNamespace(typeNamespace.Namespace)
                    .ToCompilationUnit()
                    .AddUsings("System.Text.Json.Serialization")
                    .Format()
                    .WriteTo(file.StreamWriter);
            };
        }

        void GenerateModuleInterface(ApiModule module)
        {
            var moduleName = $"{module.Name.ToPascalCase()}Module";
            Syntax.Declaration
                .Interface($"I{moduleName}")
                .Public()
                .AddSummary(module.Summary)
                .AddRemarks(module.Description)
                .AddMembers(module.Functions
                    .Select(function =>
                        function.Method(module.Name, false) as MemberDeclarationSyntax)
                    .ToArray())
                .ToFileScopedNamespace($"{projectName}.Modules.{module.Name.ToPascalCase()}")
                .ToCompilationUnit()
                // .AddUsings("System.Threading.Tasks")
                .WriteTo($"{projectPath}/{projectName}/Modules/{module.Name.ToPascalCase()}/I{moduleName}.Generated.cs");
        }

        void GenerateModuleClass(ApiModule module)
        {
            var moduleName = $"{module.Name.ToPascalCase()}Module";
            Syntax.Declaration
                .Class(moduleName)
                .AddParameterListParameters(
                    Parameter(Identifier("adapter"))
                        .WithType(ParseTypeName("ITvmSdkDllAdapter"))
                )
                .Public()
                .AddBaseListTypes(SimpleBaseType(IdentifierName($"I{moduleName}")))
                .AddSummary(module.Summary)
                .AddRemarks(module.Description)
                .AddMembers(module.Functions
                    .Select(function => function.Method(module.Name) as MemberDeclarationSyntax).ToArray())
                .ToFileScopedNamespace($"{projectName}.Modules.{module.Name.ToPascalCase()}")
                .ToCompilationUnit()
                .AddUsings("TvmSdk.DllAdapter")
                .WriteTo($"{projectPath}/{projectName}/Modules/{module.Name.ToPascalCase()}/{moduleName}.Generated.cs");
        }
    }
}