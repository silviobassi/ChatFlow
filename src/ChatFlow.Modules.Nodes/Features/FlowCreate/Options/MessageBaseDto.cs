using System.Text.Json.Serialization;

namespace ChatFlow.Modules.Nodes.Features.FlowCreate.Options;

public abstract record MessageBaseDto(
    [property: JsonPropertyName("messaging_product")]
    string MessagingProduct,
    [property: JsonPropertyName("recipient_type")]
    string? RecipientType,
    [property: JsonPropertyName("to")] string To,
    [property: JsonPropertyName("type")] string Type
);