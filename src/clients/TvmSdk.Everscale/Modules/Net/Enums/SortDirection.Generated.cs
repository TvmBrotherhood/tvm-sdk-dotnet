namespace TvmSdk.Everscale.Modules.Net;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SortDirection : byte
{
    ASC,
    DESC
}