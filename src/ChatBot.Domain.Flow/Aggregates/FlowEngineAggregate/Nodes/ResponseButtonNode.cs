using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Buttons;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Footers;
using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Headers;

namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Nodes;

public sealed record ResponseButtonNode(
    string NodeId,
    string Name,
    string MessageText, // utilizar como body text (required
    List<ButtonReply> ButtonReplies,
    Header? Header,
    FooterText? FooterText
) : ChatNode(NodeId, Name, MessageText);