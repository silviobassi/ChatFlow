using ChatFlow.Domain.Aggregates.FlowAggregate.Headers;
using ChatFlow.Modules.Nodes.Features.FlowCreate.Options;
using ChatFlow.Modules.Nodes.Features.FlowCreate.Options.ResponseButtonOption;

namespace ChatFlow.Modules.Nodes.Features.FlowCreate.Mappers;

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