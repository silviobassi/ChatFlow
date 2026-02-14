using ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Nodes;

public sealed record DocumentNode(
    string NodeId,
    string Name,
    string MessageText,
    DocumentContent DocumentContent,
    TargetNode? TargetNode = null,
    TargetFlow? TargetFlow = null
) : ChatNode(NodeId, Name, MessageText);