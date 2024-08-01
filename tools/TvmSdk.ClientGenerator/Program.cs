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
        if (args.Length == 1)
            Directory.SetCurrentDirectory(args[0]);
        
        const string projectName = "TvmSdk";
        var currentPath = AppDomain.CurrentDomain.BaseDirectory;
        var projectPath = Path.Combine(currentPath, "../../../../../src");
        var outputPath = $"{projectPath}/{projectName}/Modules";
        var everApi = await JsonUtil.DeserializeFile<API>("api.json");

        if (Directory.Exists(outputPath))
            Directory.Delete(outputPath, true);

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
            GenerateModuleClass(module, "ITvmClient");
        }

        return;

        void GenerateEnum(ApiModel.EnumOfConsts model)
        {
            var typeNamespace = typeNamespaceLookup[model.Name];
            using var file = new FileWriter(typeNamespace.Filepath);

            Syntax.Declaration.Enum(model.Name)
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
                    .ToList())
                .ToFileScopedNamespace(typeNamespace.Namespace)
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

                compilationUnit
                    .AddUsings("System.Text.Json.Serialization") // TODO: Move to globalusings?
                    .AddMembers(
                        polymorphic.ToFileScopedNamespace(typeNamespace.Namespace))
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

        void GenerateModuleClass(ApiModule module, string clientInterfaceName)
        {
            var moduleName = $"{module.Name.ToPascalCase()}Module";
            Syntax.Declaration
                .Class(moduleName)
                .AddParameterListParameters(
                    Parameter(Identifier("client"))
                        .WithType(ParseTypeName(clientInterfaceName))
                )
                .Public()
                .AddBaseListTypes(SimpleBaseType(IdentifierName($"I{moduleName}")))
                .AddSummary(module.Summary)
                .AddRemarks(module.Description)
                .AddMembers(module.Functions
                    .Select(function => function.Method(module.Name) as MemberDeclarationSyntax).ToArray())
                .ToFileScopedNamespace($"{projectName}.Modules.{module.Name.ToPascalCase()}")
                .ToCompilationUnit()
                .WriteTo($"{projectPath}/{projectName}/Modules/{module.Name.ToPascalCase()}/{moduleName}.Generated.cs");
        }
    }
}