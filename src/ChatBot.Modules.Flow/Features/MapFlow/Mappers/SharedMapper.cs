using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Footers;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Headers;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Nodes;
using ChatBot.Modules.Flow.Features.MapFlow.Options;

namespace ChatBot.Modules.Flow.Features.MapFlow.Mappers;

internal static class SharedMapper
{
    extension(FooterText? footerText)
    {
        public FooterDto? ToDto() => footerText.HasValue ? new FooterDto(Text: footerText.Value.Value) : null;
    }

    extension(HeaderText? headerText)
    {
        public HeaderTextDto? ToDto() => headerText is not null ? new HeaderTextDto(Text: headerText.Value) : null;
    }

    extension(ChatNode node)
    {
        public BodyDto ToBodyDto() => new(Text: node.MessageText);
    }
}