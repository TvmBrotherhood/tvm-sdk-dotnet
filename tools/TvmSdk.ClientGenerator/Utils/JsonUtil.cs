using System.Text.Json;
using System.Text.Json.Serialization;

namespace TvmSdk.ClientGenerator.Utils;

internal static class JsonUtil
{
    private static readonly JsonSerializerOptions Options = new()
    {
        AllowOutOfOrderMetadataProperties = true,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
        Converters =
        {
            new JsonStringEnumConverter()
        }
    };

    internal static async Task<T> DeserializeFile<T>(string path)
    {
        await using var apiFileStream = File.OpenRead(path);
        var result = await JsonSerializer.DeserializeAsync<T>(
            apiFileStream,
            Options);

        if (result == null) throw new ArgumentException($"Could not parse provided json file '{path}'");

        return result;
    }
}