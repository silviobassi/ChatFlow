using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Headers;
using ChatBot.Modules.Flow.Features.MapFlow.Options;
using ChatBot.Modules.Flow.Features.MapFlow.Options.ResponseButtonOption;

namespace ChatBot.Modules.Flow.Features.MapFlow.Mappers;

internal static class HeaderMapper
{
    extension(Header? header)
    {
        public HeaderDto? ToDto() => header switch
        {
            HeaderText t => new HeaderTextDto(t.Value),
            HeaderImageUrl img => new HeaderImageLinkDto(new ImageLinkDto(img.Value)),
            HeaderImageId id => new HeaderImageIdDto(new ImageIdDto(id.Value)),
            _ => null
        };
    }
}