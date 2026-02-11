using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.ContactOption;

public record ContactPhoneDto(
    // For meta, this is not required, but self business rules require it, so we keep it as required
    [property: JsonPropertyName("wa_id")] string WaId,
    [property: JsonPropertyName("phone")] string? Phone,
    [property: JsonPropertyName("type")] string? Type
);