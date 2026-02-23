using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options.ContactOption;

public record ContactNameDto(
    [property: JsonPropertyName("formatted_name")]
    string FormattedName,
    [property: JsonPropertyName("first_name")]
    string? FirstName,
    [property: JsonPropertyName("last_name")]
    string? LastName
);