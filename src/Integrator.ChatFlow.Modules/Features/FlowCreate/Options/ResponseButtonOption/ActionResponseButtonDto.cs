using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.ResponseButtonOption;

public record ActionResponseButtonDto(
    [property: JsonPropertyName("buttons")]
    List<ResponseButtonReplyDto> Buttons);