using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options;

public record BodyDto([property: JsonPropertyName("text")] string Text);