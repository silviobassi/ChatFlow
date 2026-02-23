using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Nodes;

public sealed record ContactNode(
    string NodeId,
    string Name,
    string MessageText,
    ContactName ContactName,
    List<ContactPhone> Phones,
    TargetNode? TargetNode = null,
    TargetFlow? TargetFlow = null
) : ChatNode(NodeId, Name, MessageText);