using ChatFlow.Domain.Aggregates.FlowAggregate.ValuesObject;

namespace ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;

public sealed record DocumentNode(
    string NodeId,
    string Name,
    string MessageText,
    DocumentContent DocumentContent
) : ChatNode(NodeId, Name, MessageText);