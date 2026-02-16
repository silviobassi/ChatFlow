using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Buttons;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Footers;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Headers;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Nodes;

public sealed record ResponseButtonNode(
    string NodeId,
    string Name,
    string MessageText, // utilizar como body text (required
    List<ButtonReply> ButtonReplies,
    Header? Header,
    FooterText? FooterText
) : ChatNode(NodeId, Name, MessageText);