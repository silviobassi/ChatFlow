using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.ResponseButtonOption;

public record ImageLinkDto([property: JsonPropertyName("link")] string Link);