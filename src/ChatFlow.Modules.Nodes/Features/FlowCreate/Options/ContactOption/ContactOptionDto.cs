using System.Text.Json.Serialization;

namespace ChatFlow.Modules.Nodes.Features.FlowCreate.Options.ContactOption;

public record ContactOptionDto(
    string To,
    [property: JsonPropertyName("contacts")]
    List<ContactDto> Contacts
) : MessageBaseDto("whatsapp", null, To, "contacts");