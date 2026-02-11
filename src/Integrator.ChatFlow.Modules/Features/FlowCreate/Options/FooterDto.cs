using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options;

public record FooterDto([property: JsonPropertyName("text")] string Text);