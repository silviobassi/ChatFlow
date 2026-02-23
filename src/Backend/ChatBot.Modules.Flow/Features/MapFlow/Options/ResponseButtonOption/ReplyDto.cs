using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options.ResponseButtonOption;

public record ReplyDto(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("title")] string Title
);