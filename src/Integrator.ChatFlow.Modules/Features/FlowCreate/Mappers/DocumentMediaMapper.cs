using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.ValuesObject;
using Integrator.ChatFlow.Modules.Features.FlowCreate.Options.DocumentOption;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Mappers;

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