using ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;
using ChatFlow.Modules.Nodes.Features.MapFlow.Options.TextOption;

namespace ChatFlow.Modules.Nodes.Features.MapFlow.Mappers;

public static class TextMapper
{
    extension(TextNode node)
    {
        public TextOptionDto ToDto(string userPhone) => new(To: userPhone, node.ToTextContent());

        private TextContentDto ToTextContent() => new(node.TextContent.PreviewUrl, node.MessageText);
    }
}