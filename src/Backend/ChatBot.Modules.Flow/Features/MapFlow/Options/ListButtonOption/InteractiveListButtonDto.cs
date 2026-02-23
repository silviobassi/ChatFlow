using System.Text.Json.Serialization;

namespace ChatBot.Modules.Flow.Features.MapFlow.Options.ListButtonOption;

public record InteractiveListButtonDto(
    BodyDto Body,
    [property: JsonPropertyName("action")] ActionListButtonDto Action,
    FooterDto? Footer,
    HeaderDto? Header
) : InteractiveBaseDto("list", Body, Footer, Header);