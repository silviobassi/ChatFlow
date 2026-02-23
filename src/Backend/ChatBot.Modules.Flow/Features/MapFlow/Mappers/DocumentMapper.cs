using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Nodes;
using ChatBot.Modules.Flow.Features.MapFlow.Options.DocumentOption;

namespace ChatBot.Modules.Flow.Features.MapFlow.Mappers;

public static class DocumentMapper
{
    extension(DocumentNode node)
    {
        public DocumentOptionDto ToDto(string userPhone) => new(
            To: userPhone, Document: node.DocumentContent.ToDto(userPhone)
        );
    }
}