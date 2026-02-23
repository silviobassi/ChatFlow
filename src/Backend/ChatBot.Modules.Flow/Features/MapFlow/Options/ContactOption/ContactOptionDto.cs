using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options.ContactOption;

public record ContactOptionDto(
    string To,
    [property: JsonPropertyName("contacts")]
    List<ContactDto> Contacts
) : MessageBaseDto("whatsapp", null, To, "contacts");