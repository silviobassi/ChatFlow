using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options;

public abstract record InteractiveBaseDto(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("body")] BodyDto Body,
    [property: JsonPropertyName("footer")] FooterDto? Footer = null,
    [property: JsonPropertyName("header")] HeaderDto? Header = null
);