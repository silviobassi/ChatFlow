using System.Text.Json.Serialization;

namespace ChatFlow.Modules.Nodes.Features.FlowCreate.Options.ContactOption;

public record ContactDto(
    [property: JsonPropertyName("Name")] ContactNameDto Name,
    [property: JsonPropertyName("phones")] List<ContactPhoneDto> Phones
);