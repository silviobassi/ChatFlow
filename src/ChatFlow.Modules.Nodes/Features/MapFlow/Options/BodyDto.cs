using System.Text.Json.Serialization;

namespace ChatFlow.Modules.Nodes.Features.MapFlow.Options;

public record BodyDto([property: JsonPropertyName("text")] string Text);