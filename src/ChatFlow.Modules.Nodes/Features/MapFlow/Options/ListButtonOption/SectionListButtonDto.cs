using System.Text.Json.Serialization;

namespace ChatFlow.Modules.Nodes.Features.MapFlow.Options.ListButtonOption;

public record SectionListButtonDto(
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("rows")] List<RowDto> Rows
);