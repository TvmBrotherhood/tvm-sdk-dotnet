using System.Text.Json;

namespace TvmSdk.Tests.Extensions;

public static class JsonExtensions
{
    public static JsonElement ToJsonElement(this object element) {
        return JsonDocument.Parse(JsonSerializer.Serialize(element)).RootElement;
    }
}