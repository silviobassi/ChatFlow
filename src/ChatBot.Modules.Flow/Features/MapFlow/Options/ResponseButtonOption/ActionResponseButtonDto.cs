using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options.ResponseButtonOption;

public record ActionResponseButtonDto(
    [property: JsonPropertyName("buttons")]
    List<ResponseButtonReplyDto> Buttons);