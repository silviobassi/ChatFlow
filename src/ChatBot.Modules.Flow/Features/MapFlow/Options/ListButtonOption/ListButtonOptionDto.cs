using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options.ListButtonOption;

public record ListButtonOptionDto(
    string To,
    [property: JsonPropertyName("interactive")]
    InteractiveListButtonDto Interactive
)
    : MessageBaseDto("whatsapp", "individual", To, "interactive");