using ChatFlow.Domain.Aggregates.FlowAggregate.ValuesObject;

namespace ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;

public record TextNode(
    string NodeId,
    string Name,
    string MessageText, // utilizar como texto do corpo da mensagem (required)
    TextContent TextContent
) : ChatNode(NodeId, Name, MessageText);