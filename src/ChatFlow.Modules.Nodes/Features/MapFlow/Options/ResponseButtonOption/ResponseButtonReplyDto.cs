using System.Text.Json.Serialization;

namespace ChatFlow.Modules.Nodes.Features.MapFlow.Options.ResponseButtonOption;

public record ResponseButtonReplyDto(
    [property: JsonPropertyName("reply")] ReplyDto Reply,
    [property: JsonPropertyName("type")] string Type = "reply"
);