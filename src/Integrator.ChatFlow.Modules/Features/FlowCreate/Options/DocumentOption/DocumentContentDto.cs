using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.DocumentOption;

public sealed record DocumentContentDto(
    [property: JsonPropertyName("id")] string? Id = null,
    [property: JsonPropertyName("link")] string? Link = null,
    [property: JsonPropertyName("caption")] string? Caption = null,
    [property: JsonPropertyName("filename")] string? FileName = null
);