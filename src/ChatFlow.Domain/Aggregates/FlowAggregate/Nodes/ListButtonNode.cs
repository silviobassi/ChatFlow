using ChatFlow.Domain.Aggregates.FlowAggregate.Buttons;
using ChatFlow.Domain.Aggregates.FlowAggregate.Footers;
using ChatFlow.Domain.Aggregates.FlowAggregate.Headers;

namespace ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;

public sealed record ListButtonNode(
    string NodeId,
    string Name,
    string MessageText, // utilizar como body text
    ButtonText ButtonText,
    List<SectionButton> SectionsButtons,
    FooterText? FooterText = null,
    HeaderText? HeaderText = null
) : ChatNode(NodeId, Name, MessageText);