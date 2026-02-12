using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options.ResponseButtonOption;

public record ImageLinkDto([property: JsonPropertyName("link")] string Link);