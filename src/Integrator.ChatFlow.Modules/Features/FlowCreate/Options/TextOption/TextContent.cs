using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.TextOption;

public record TextContent(
    [property: JsonPropertyName("body")] string Body,
    [property: JsonPropertyName("preview_url")] bool PreviewUrl = false
);