using System.Text.Json.Serialization;
using Integrator.ChatFlow.Modules.Features.FlowCreate.Options.ResponseButtonOption;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options;

public record HeaderTextDto(
    [property: JsonPropertyName("text")] string Text,
    [property: JsonPropertyName("type")] string Type = "text"
);

public record HeaderImageLinkDto(
    [property: JsonPropertyName("image")] ImageLinkDto Image,
    [property: JsonPropertyName("type")] string Type = "image"
);

public record HeaderImageIdDto(
    [property: JsonPropertyName("image")] ImageIdDto Image,
    [property: JsonPropertyName("type")] string Type = "image"
);