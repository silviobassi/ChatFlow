using ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;
using ChatFlow.Modules.Nodes.Features.FlowCreate.Mappers;
using ChatFlow.Modules.Nodes.Features.FlowCreate.Options;
using ChatFlow.Modules.Nodes.Features.FlowCreate.Options.ContactOption;
using ChatFlow.Modules.Nodes.Features.FlowCreate.Options.DocumentOption;
using ChatFlow.Modules.Nodes.Features.FlowCreate.Options.ListButtonOption;
using ChatFlow.Modules.Nodes.Features.FlowCreate.Options.ResponseButtonOption;
using ChatFlow.Modules.Nodes.Features.FlowCreate.Options.TextOption;

namespace ChatFlow.Modules.Nodes.Features.FlowCreate;

public static class MessageAdapter
{
    extension(ChatNode node)
    {
        public MessageBaseDto MapNodeToDto(string userPhone) => node switch
        {
            ListButtonNode listButtonNode => ToDto(listButtonNode, userPhone),
            ResponseButtonNode responseButtonNode => ToDo(responseButtonNode, userPhone),
            ContactNode contactNode => ToDo(contactNode, userPhone),
            DocumentNode documentNode => ToDo(documentNode, userPhone),
            TextNode textNode => ToDo(textNode, userPhone),

            _ => throw new NotSupportedException(
                $"O tipo de nó '{node.GetType().Name}' não é suportado para mapeamento.")
        };
    }

    private static ListButtonOptionDto ToDto(ListButtonNode node, string userPhone) => node.ToDto(userPhone);

    private static ResponseButtonOptionDto ToDo(ResponseButtonNode node, string userPhone) => node.ToDto(userPhone);

    private static ContactOptionDto ToDo(ContactNode node, string userPhone) => node.ToDo(userPhone);

    private static DocumentOptionDto ToDo(DocumentNode node, string userPhone) => node.ToDto(userPhone);

    private static TextOptionDto ToDo(TextNode node, string userPhone) => node.ToDto(userPhone);
}