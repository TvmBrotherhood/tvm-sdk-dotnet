namespace TvmSdk.ClientGenerator.Models;

public class EnumInfo
{
    public required string Name { get; init; }

    public required int? Value { get; init; }

    public string? Summary { get; init; }

    public string? Remarks { get; init; }
}