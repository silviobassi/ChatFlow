using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options;

public abstract record InteractiveBaseDto(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("body")] BodyDto Body,
    [property: JsonPropertyName("footer")] FooterDto? Footer = null,
    [property: JsonPropertyName("header")] object? Header = null
);