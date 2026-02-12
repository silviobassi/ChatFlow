using ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Nodes;

public sealed record ContactNode(
    string NodeId,
    string Name,
    string MessageText,
    ContactName ContactName,
    List<ContactPhone> Phones
) : ChatNode(NodeId, Name, MessageText);