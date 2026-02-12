using ChatFlow.Domain.Aggregates.FlowAggregate.Footers;
using ChatFlow.Domain.Aggregates.FlowAggregate.Headers;
using ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;
using ChatFlow.Modules.Nodes.Features.MapFlow.Options;

namespace ChatFlow.Modules.Nodes.Features.MapFlow.Mappers;

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