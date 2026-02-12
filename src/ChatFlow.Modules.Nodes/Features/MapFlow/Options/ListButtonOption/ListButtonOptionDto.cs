using System.Text.Json.Serialization;

namespace ChatFlow.Modules.Nodes.Features.MapFlow.Options.ListButtonOption;

public record ListButtonOptionDto(
    string To,
    [property: JsonPropertyName("interactive")]
    InteractiveListButtonDto Interactive
)
    : MessageBaseDto("whatsapp", "individual", To, "interactive");