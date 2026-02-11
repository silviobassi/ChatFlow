using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.ContactOption;

public record ContactDto(
    [property: JsonPropertyName("Name")] ContactNameDto Name,
    [property: JsonPropertyName("phones")] List<ContactPhoneDto> Phones
);