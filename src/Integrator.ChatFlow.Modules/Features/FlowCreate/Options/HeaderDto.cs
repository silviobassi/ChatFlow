using System.Text.Json.Serialization;
using Integrator.ChatFlow.Modules.Features.FlowCreate.Options.ResponseButtonOption;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options;

[JsonDerivedType(typeof(HeaderTextDto))]
[JsonDerivedType(typeof(HeaderImageLinkDto))]
[JsonDerivedType(typeof(HeaderImageIdDto))]
public record HeaderDto([property: JsonPropertyName("type")] string Type);

public record HeaderTextDto(
    [property: JsonPropertyName("text")] string Text,
    [property: JsonPropertyName("type")] string Type = "text"
) : HeaderDto(Type);

public record HeaderImageLinkDto(
    [property: JsonPropertyName("image")] ImageLinkDto Image,
    string Type = "image"
) : HeaderDto(Type);

public record HeaderImageIdDto(
    [property: JsonPropertyName("image")] ImageIdDto Image,
    string Type = "image"
) : HeaderDto(Type);