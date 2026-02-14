using ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Nodes;

public record TextNode(
    string NodeId,
    string Name,
    string MessageText, // utilizar como texto do corpo da mensagem (required)
    TextContent TextContent,
    NavigationTargetFlow? NavigationTargetFlow = null,
    NavigationTargetNode? NavigationTargetNode = null
) : ChatNode(NodeId, Name, MessageText);

// O fluxo de texto pode ser utilizado para encerrar um fluxo, ou seja, o cliente receberá apenas uma mensagem de texto
// e não terá mais opções de resposta. Desta forma, TargetFlow e TargetNode são opcionais.