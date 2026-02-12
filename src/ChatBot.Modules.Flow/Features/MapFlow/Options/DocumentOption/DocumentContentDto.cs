using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options.DocumentOption;

[JsonDerivedType(typeof(DocumentContentWithIdDto))]
[JsonDerivedType(typeof(DocumentContentWithLinkDto))]
public abstract record DocumentContentDto(
    [property: JsonPropertyName("caption")]
    string? Caption = null,
    [property: JsonPropertyName("filename")]
    string? FileName = null
);

public record DocumentContentWithIdDto(
    [property: JsonPropertyName("id")] string Id,
    string? Caption = null,
    string? FileName = null
) : DocumentContentDto(Caption, FileName);

public record DocumentContentWithLinkDto(
    [property: JsonPropertyName("link")] string Link,
    string? Caption = null,
    string? FileName = null
) : DocumentContentDto(Caption, FileName);