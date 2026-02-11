using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.ContactOption;

public record ContactOptionDto(
    string To,
    [property: JsonPropertyName("contacts")] List<ContactDto> Contacts
) : MessageBaseDto(To, "contacts");