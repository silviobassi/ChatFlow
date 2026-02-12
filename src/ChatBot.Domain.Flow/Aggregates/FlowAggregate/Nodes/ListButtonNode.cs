using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Buttons;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Footers;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Headers;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Nodes;

public sealed record ListButtonNode(
    string NodeId,
    string Name,
    string MessageText, // utilizar como body text
    ButtonText ButtonText,
    List<SectionButton> SectionsButtons,
    FooterText? FooterText = null,
    HeaderText? HeaderText = null
) : ChatNode(NodeId, Name, MessageText);