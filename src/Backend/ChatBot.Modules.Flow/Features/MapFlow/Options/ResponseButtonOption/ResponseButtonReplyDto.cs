using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options.ResponseButtonOption;

public record ResponseButtonReplyDto(
    [property: JsonPropertyName("reply")] ReplyDto Reply,
    [property: JsonPropertyName("type")] string Type = "reply"
);