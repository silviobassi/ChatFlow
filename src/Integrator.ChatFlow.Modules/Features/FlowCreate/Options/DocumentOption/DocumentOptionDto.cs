using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.DocumentOption;

public record DocumentOptionDto(
    string To,
    [property: JsonPropertyName("document")]
    DocumentContentDto Document
) : MessageBaseDto(To, "document", RecipientType: "individual");