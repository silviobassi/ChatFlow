using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options.ResponseButtonOption;

public record ImageIdDto([property: JsonPropertyName("id")] string Id);