using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options;

public abstract record MessageBaseDto(
    [property: JsonPropertyName("to")] string To,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("messaging_product")]
    string MessagingProduct = "whatsapp",
    [property: JsonPropertyName("recipient_type")]
    string? RecipientType = null
);