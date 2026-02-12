using System.Text.Json.Serialization;

namespace ChatFlow.Modules.Nodes.Features.MapFlow.Options.ResponseButtonOption;

public record ActionResponseButtonDto(
    [property: JsonPropertyName("buttons")]
    List<ResponseButtonReplyDto> Buttons);