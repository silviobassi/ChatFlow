using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.ResponseButtonOption;

public record ResponseButtonReplyDto(
    [property: JsonPropertyName("reply")] ReplyDto Reply,
    [property: JsonPropertyName("type")] string Type = "reply"
);