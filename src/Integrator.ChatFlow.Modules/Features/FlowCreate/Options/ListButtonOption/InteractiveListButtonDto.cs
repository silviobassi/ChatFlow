using System.Text.Json.Serialization;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Options.ListButtonOption;

public record InteractiveListButtonDto(
    BodyDto Body,
    [property: JsonPropertyName("action")] ActionListButtonDto Action,
    FooterDto? Footer,
    object? Header
) : InteractiveBaseDto("list", Body, Footer, Header);