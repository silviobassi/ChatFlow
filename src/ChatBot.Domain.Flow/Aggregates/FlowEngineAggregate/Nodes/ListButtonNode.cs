using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Buttons;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Footers;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Headers;

namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Nodes;

public sealed record ListButtonNode(
    string NodeId,
    string Name,
    string MessageText, // utilizar como body text
    ButtonText ButtonText,
    List<SectionButton> SectionsButtons,
    FooterText? FooterText = null,
    HeaderText? HeaderText = null
) : ChatNode(NodeId, Name, MessageText);