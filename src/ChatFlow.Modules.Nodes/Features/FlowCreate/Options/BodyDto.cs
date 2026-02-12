using System.Text.Json.Serialization;

namespace ChatFlow.Modules.Nodes.Features.FlowCreate.Options;

public record BodyDto([property: JsonPropertyName("text")] string Text);