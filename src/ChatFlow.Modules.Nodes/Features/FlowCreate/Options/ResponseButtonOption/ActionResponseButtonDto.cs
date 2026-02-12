using System.Text.Json.Serialization;

namespace ChatFlow.Modules.Nodes.Features.FlowCreate.Options.ResponseButtonOption;

public record ActionResponseButtonDto(
    [property: JsonPropertyName("buttons")]
    List<ResponseButtonReplyDto> Buttons);