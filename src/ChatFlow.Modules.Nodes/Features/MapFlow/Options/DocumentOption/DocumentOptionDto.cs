using System.Text.Json.Serialization;

namespace ChatFlow.Modules.Nodes.Features.MapFlow.Options.DocumentOption;

public record DocumentOptionDto(
    string To,
    [property: JsonPropertyName("document")]
    DocumentContentDto Document
) : MessageBaseDto("whatsapp", "individual", To, "document");