using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Nodes;
using ChatBot.Modules.Flow.Features.MapFlow.Options.TextOption;

namespace ChatBot.Modules.Flow.Features.MapFlow.Mappers;

public static class TextMapper
{
    extension(TextNode node)
    {
        public TextOptionDto ToDto(string userPhone) => new(To: userPhone, node.ToTextContent());

        private TextContentDto ToTextContent() => new(node.TextContent.PreviewUrl, node.MessageText);
    }
}