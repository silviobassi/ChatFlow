using System.Text.Json.Serialization;

namespace ChatFlow.Modules.Nodes.Features.MapFlow.Options;

public record FooterDto([property: JsonPropertyName("text")] string Text);