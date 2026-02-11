using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options;

public record BodyDto([property: JsonPropertyName("text")] string Text);