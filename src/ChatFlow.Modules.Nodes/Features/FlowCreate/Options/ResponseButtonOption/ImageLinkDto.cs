using System.Text.Json.Serialization;

namespace ChatFlow.Modules.Nodes.Features.FlowCreate.Options.ResponseButtonOption;

public record ImageLinkDto([property: JsonPropertyName("link")] string Link);