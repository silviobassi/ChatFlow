using ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Buttons;

public readonly record struct RowListButtonBuilder
{
    private string Id { get; init; }
    private string Title { get; init; }
    private string? Description { get; init; }
    private NavigationTargetNode? NavigationTargetNode { get; init; }
    private NavigationTargetFlow? NavigationTargetFlow { get; init; }

    private RowListButtonBuilder(string id, string title)
    {
        Id = id;
        Title = title;
        Description = null;
        NavigationTargetNode = null;
        NavigationTargetFlow = null;
    }

    public static RowListButtonBuilder Builder(string id, string title) => new(id, title);

    public RowListButtonBuilder WithDescription(string description)
    {
        return this with { Description = description };
    }

    public RowListButtonBuilder WithNavigationTargetNode(NavigationTargetNode navigationTargetNode)
    {
        if (NavigationTargetNode is not null)
            throw new InvalidOperationException("❌ Não é permitido definir navegação para flow e node ao mesmo tempo.");

        return this with { NavigationTargetNode = navigationTargetNode };
    }

    public RowListButtonBuilder WithNavigationTargetFlow(NavigationTargetFlow navigationTargetFlow)
    {
        if (NavigationTargetNode is not null)
            throw new InvalidOperationException("❌ Não é permitido definir navegação para flow e node ao mesmo tempo.");

        return this with { NavigationTargetFlow = navigationTargetFlow };
    }

    public RowListButton Build()
    {
        if (NavigationTargetNode is not null && NavigationTargetFlow is not null)
            throw new InvalidOperationException("❌ Não é permitido definir navegação, ao botão da lista, sendo flow e node ao mesmo tempo.");

        if (string.IsNullOrWhiteSpace(Id))
            throw new InvalidOperationException("O ID do botão é obrigatório.");

        if (string.IsNullOrWhiteSpace(Title))
            throw new InvalidOperationException("O Título do botão é obrigatório.");

        return new RowListButton(Id, Title, Description, NavigationTargetNode, NavigationTargetFlow);
    }
}