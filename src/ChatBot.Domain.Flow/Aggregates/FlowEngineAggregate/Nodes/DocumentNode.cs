using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Nodes;

public sealed record DocumentNode(
    string NodeId,
    string Name,
    string MessageText,
    DocumentContent DocumentContent,
    TargetNode? TargetNode = null,
    TargetFlow? TargetFlow = null
) : ChatNode(NodeId, Name, MessageText);