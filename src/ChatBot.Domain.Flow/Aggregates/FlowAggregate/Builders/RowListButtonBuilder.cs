using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Buttons;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Builders;

public readonly record struct RowListButtonBuilder
{
    private string Id { get; init; }
    private string Title { get; init; }
    private string? Description { get; init; }
    private TargetNode? TargetNode { get; init; }
    private TargetFlow? TargetFlow { get; init; }

    private RowListButtonBuilder(string id, string title)
    {
        Id = id;
        Title = title;
        Description = null;
        TargetNode = null;
        TargetFlow = null;
    }

    public static RowListButtonBuilder Builder(string id, string title) => new(id, title);

    public RowListButtonBuilder WithDescription(string description)
    {
        return this with { Description = description };
    }

    public RowListButtonBuilder WithNavigationTargetNode(TargetNode targetNode)
    {
        return this with
        {
            TargetNode = targetNode,
            TargetFlow = null
        };
    }

    public RowListButtonBuilder WithNavigationTargetFlow(TargetFlow targetFlow)
    {
        return this with
        {
            TargetNode = null,
            TargetFlow = targetFlow
        };
    }

    public RowListButton Build()
    {
        if (string.IsNullOrWhiteSpace(Id))
            throw new InvalidOperationException("O ID do botão é obrigatório.");

        if (string.IsNullOrWhiteSpace(Title))
            throw new InvalidOperationException("O Título do botão é obrigatório.");

        return new RowListButton(Id, Title, Description, TargetNode, TargetFlow);
    }
}