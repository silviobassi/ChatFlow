using ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Buttons;

public sealed record ButtonReply()
{
    public string Id { get; } = string.Empty;
    public string Title { get; } = string.Empty;
    public TargetNode? TargetNode { get; }
    public TargetFlow? TargetFlow { get; }
    public string Type { get; } = "reply";

    private ButtonReply(string id, string title, TargetNode? targetNode, TargetFlow? targetFlow) : this()
    {
        Id = id;
        Title = title;
        TargetNode = targetNode;
        TargetFlow = targetFlow;
    }

    public static ButtonReply CreateWithTargetNode(string id, string title, TargetNode targetNode)
        => new(id, title, targetNode, null);

    public static ButtonReply CreateWithTargetFlow(string id, string title, TargetFlow targetFlow)
        => new(id, title, null, targetFlow);
}