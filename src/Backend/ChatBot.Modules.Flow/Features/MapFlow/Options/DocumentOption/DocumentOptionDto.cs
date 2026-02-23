using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options.DocumentOption;

public record DocumentOptionDto(
    string To,
    [property: JsonPropertyName("document")]
    DocumentContentDto Document
) : MessageBaseDto("whatsapp", "individual", To, "document");