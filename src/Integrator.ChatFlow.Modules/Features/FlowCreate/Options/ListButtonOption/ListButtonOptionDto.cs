using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.ListButtonOption;

public record ListButtonOptionDto(
    string To,
    [property: JsonPropertyName("interactive")]
    InteractiveListButtonDto Interactive
)
    : MessageBaseDto(To, "interactive", RecipientType: "individual");