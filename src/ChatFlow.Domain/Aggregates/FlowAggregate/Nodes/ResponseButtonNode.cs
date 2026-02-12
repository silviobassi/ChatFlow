using ChatFlow.Domain.Aggregates.FlowAggregate.Buttons;
using ChatFlow.Domain.Aggregates.FlowAggregate.Footers;
using ChatFlow.Domain.Aggregates.FlowAggregate.Headers;

namespace ChatFlow.Domain.Aggregates.FlowAggregate.Nodes;

public record ResponseButtonNode(
    string NodeId,
    string Name,
    string MessageText, // utilizar como body text (required
    List<ButtonReply> ButtonReplies,
    Header? Header,
    FooterText? FooterText
) : ChatNode(NodeId, Name, MessageText);