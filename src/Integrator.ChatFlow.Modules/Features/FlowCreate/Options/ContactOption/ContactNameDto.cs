using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.ContactOption;

public record ContactNameDto(
    [property: JsonPropertyName("formatted_name")]
    string FormattedName,
    [property: JsonPropertyName("first_name")]
    string? FirstName,
    [property: JsonPropertyName("last_name")]
    string? LastName
);