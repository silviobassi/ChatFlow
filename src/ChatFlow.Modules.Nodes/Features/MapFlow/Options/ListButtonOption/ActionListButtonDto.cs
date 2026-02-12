using System.Text.Json.Serialization;

namespace ChatFlow.Modules.Nodes.Features.MapFlow.Options.ListButtonOption;

public record ActionListButtonDto(
    [property: JsonPropertyName("button")] string Button,
    [property: JsonPropertyName("sections")] List<SectionListButtonDto> Sections
);