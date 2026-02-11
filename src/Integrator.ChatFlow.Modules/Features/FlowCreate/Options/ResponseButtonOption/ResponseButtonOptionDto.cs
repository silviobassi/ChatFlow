using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.ResponseButtonOption;

public record ResponseButtonOptionDto(
    string To,
    [property: JsonPropertyName("interactive")]
    InteractiveButtonDto Interactive
)
    : MessageBaseDto(To, "interactive", RecipientType: "individual");