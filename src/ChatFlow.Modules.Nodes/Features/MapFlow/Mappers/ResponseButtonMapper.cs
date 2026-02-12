using ChatFlow.Domain.Aggregates.FlowAggregate.Buttons;
using ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;
using ChatFlow.Modules.Nodes.Features.MapFlow.Options.ResponseButtonOption;

namespace ChatFlow.Modules.Nodes.Features.MapFlow.Mappers;

internal static class ResponseButtonMapper
{
    extension(ResponseButtonNode node)
    {
        public ResponseButtonOptionDto ToDto(string userPhone) =>
            new(To: userPhone, Interactive: node.ToInteractiveButtonDto());

        private InteractiveButtonDto ToInteractiveButtonDto() => new(
            Body: node.ToBodyDto(),
            Action: node.ToActionResponseButtonDto(),
            Footer: node.FooterText.ToDto(),
            Header: node.Header.ToDto()
        );

        private ActionResponseButtonDto ToActionResponseButtonDto() => new(
            Buttons: node.ButtonReplies.ToResponseButtonRepliesDto()
        );
    }

    extension(List<ButtonReply> replies)
    {
        private List<ResponseButtonReplyDto> ToResponseButtonRepliesDto() =>
            replies.Select(br => br.ToResponseButtonReplyDto()).ToList();
    }

    extension(ButtonReply br)
    {
        private ResponseButtonReplyDto ToResponseButtonReplyDto() => new(Reply: br.ToReplyDto(), Type: br.Type);

        private ReplyDto ToReplyDto() => new(Id: br.Id, Title: br.Title);
    }
}