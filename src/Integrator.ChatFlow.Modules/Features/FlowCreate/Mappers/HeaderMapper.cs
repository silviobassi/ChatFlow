using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Headers;
using Integrator.ChatFlow.Modules.Features.FlowCreate.Options;
using Integrator.ChatFlow.Modules.Features.FlowCreate.Options.ResponseButtonOption;

namespace Integrator.ChatFlow.Modules.Features.FlowCreate.Mappers;

internal static class HeaderMapper
{
    extension(Header? header)
    {
        public object? ToDto() => header switch
        {
            HeaderText t => new HeaderTextDto(t.Value),
            HeaderImageUrl img => new HeaderImageLinkDto(new ImageLinkDto(img.Value)),
            HeaderImageId id => new HeaderImageIdDto(new ImageIdDto(id.Value)),
            _ => null
        };
    }
}