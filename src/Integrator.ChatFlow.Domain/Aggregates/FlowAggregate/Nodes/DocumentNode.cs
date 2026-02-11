using Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.ValuesObject;

namespace Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;

public sealed record DocumentNode(
    string NodeId,
    string Name,
    string MessageText,
    DocumentContent DocumentContent
) : ChatNode(NodeId, Name, MessageText);