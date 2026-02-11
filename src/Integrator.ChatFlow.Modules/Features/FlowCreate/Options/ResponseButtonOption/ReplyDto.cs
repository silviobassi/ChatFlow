using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.ResponseButtonOption;

public record ReplyDto(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("title")] string Title
);