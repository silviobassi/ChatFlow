using ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;
using ChatBot.Modules.Flow.Features.MapFlow.Options.DocumentOption;

namespace ChatBot.Modules.Flow.Features.MapFlow.Mappers;

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