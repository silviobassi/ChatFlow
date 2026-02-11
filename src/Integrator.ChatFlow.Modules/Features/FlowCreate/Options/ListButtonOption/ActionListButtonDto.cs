using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.ListButtonOption;

public record ActionListButtonDto(
    [property: JsonPropertyName("button")] string Button,
    [property: JsonPropertyName("sections")] List<SectionListButtonDto> Sections
);