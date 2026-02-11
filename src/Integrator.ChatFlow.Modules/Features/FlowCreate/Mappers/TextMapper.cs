using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;
using Integrator.ChatFlow.Modules.Features.FlowCreate.Options.TextOption;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Mappers;

public static class TextMapper
{
    extension(TextNode node)
    {
        public TextOptionDto ToDto(string userPhone) => new(To: userPhone, node.ToTextContent());

        private TextContentDto ToTextContent() => new(node.TextContent.PreviewUrl, node.MessageText);
    }
}