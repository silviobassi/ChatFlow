using ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;
using ChatFlow.Modules.Nodes.Features.MapFlow.Options.DocumentOption;

namespace ChatFlow.Modules.Nodes.Features.MapFlow.Mappers;

public static class DocumentMapper
{
    extension(DocumentNode node)
    {
        public DocumentOptionDto ToDto(string userPhone) => new(
            To: userPhone, Document: node.DocumentContent.ToDto(userPhone)
        );
    }
}