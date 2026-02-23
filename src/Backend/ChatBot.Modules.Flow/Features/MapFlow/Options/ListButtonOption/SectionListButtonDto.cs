using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options.ListButtonOption;

public record SectionListButtonDto(
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("rows")] List<RowDto> Rows
);