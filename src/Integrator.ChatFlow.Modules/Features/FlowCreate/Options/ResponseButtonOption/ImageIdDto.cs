using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.ResponseButtonOption;

public record ImageIdDto([property: JsonPropertyName("id")] string Id);