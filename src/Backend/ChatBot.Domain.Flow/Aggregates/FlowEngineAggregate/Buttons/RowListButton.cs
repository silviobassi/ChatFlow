using ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowEngineAggregate.Buttons;

public sealed record RowListButton
{
    public string Id { get; }
    public string Title { get; }
    public string? Description { get; }
    public TargetNode? TargetNode { get; }
    public TargetFlow? TargetFlow { get; }

    private RowListButton(string id, string title, string? description, TargetNode? targetNode, TargetFlow? targetFlow)
    {
        Id = id;
        Title = title;
        Description = description;
        TargetNode = targetNode;
        TargetFlow = targetFlow;
    }

    public static RowListButton CreateWithTargetNode(string id, string title, TargetNode targetNode,
        string? description = null)
        => new(id, title, description, targetNode, null);

    public static RowListButton CreateWithTargetFlow(string id, string title, TargetFlow targetFlow,
        string? description = null) =>
        new(id, title, description, null, targetFlow);
}