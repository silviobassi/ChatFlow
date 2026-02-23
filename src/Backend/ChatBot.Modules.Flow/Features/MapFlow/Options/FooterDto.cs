using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options;

public record FooterDto([property: JsonPropertyName("text")] string Text);