using System.Text.Json.Serialization;

namespace ChatFlow.Modules.Nodes.Features.FlowCreate.Options.ResponseButtonOption;

public record ImageIdDto([property: JsonPropertyName("id")] string Id);