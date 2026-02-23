using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options.TextOption;

public record TextContentDto(
    [property: JsonPropertyName("preview_url")] bool PreviewUrl,
    [property: JsonPropertyName("body")] string Body
);