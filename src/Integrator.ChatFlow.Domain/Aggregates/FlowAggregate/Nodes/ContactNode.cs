using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.ValuesObject;

namespace Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;

public sealed record ContactNode(
    string NodeId,
    string Name,
    string MessageText,
    ContactName ContactName,
    List<ContactPhone> Phones
) : ChatNode(NodeId, Name, MessageText);