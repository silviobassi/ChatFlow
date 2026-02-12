using ChatFlow.Domain.Aggregates.FlowAggregate.ValuesObject;
using ChatFlow.Modules.Nodes.Features.FlowCreate.Options.DocumentOption;

namespace ChatFlow.Modules.Nodes.Features.FlowCreate.Mappers;

public static class DocumentMediaMapper
{
    extension(DocumentContent documentContent)
    {
        public DocumentContentDto ToDto(string userPhone)
        {
            var media = documentContent.Media;

            return media switch
            {
                DocumentLink link => new DocumentContentWithLinkDto(
                    link.Value,
                    documentContent.Caption,
                    documentContent.Filename
                ),
                DocumentId id => new DocumentContentWithIdDto(
                    id.Value,
                    documentContent.Caption,
                    documentContent.Filename
                ),
                _ => throw new NotSupportedException($"Tipo {media.GetType().Name} não suportado.")
            };
        }
    }
}