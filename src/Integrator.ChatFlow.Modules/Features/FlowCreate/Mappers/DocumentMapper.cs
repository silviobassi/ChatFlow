using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;
using Integrator.ChatFlow.Modules.Features.FlowCreate.Options.DocumentOption;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Mappers;

public static class DocumentMapper
{
    extension(DocumentNode node)
    {
        public DocumentOptionDto ToDto(string userPhone) => new(
            To: userPhone, Document: node.DocumentContent.ToDto(userPhone)
        );
    }
}