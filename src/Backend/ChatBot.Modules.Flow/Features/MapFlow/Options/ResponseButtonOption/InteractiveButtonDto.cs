namespace ChatBot.Modules.Flow.Features.MapFlow.Options.ResponseButtonOption;

public record InteractiveButtonDto(
    BodyDto Body,
    ActionResponseButtonDto Action,
    FooterDto? Footer,
    HeaderDto? Header
) : InteractiveBaseDto("button", Body, Footer, Header);