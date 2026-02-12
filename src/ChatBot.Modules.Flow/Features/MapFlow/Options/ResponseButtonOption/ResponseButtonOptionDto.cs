using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options.ResponseButtonOption;

public record ResponseButtonOptionDto(
    string To,
    [property: JsonPropertyName("interactive")]
    InteractiveButtonDto Interactive
)
    : MessageBaseDto("whatsapp", "individual", To, "interactive");