using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options.ContactOption;

public record ContactDto(
    [property: JsonPropertyName("Name")] ContactNameDto Name,
    [property: JsonPropertyName("phones")] List<ContactPhoneDto> Phones
);