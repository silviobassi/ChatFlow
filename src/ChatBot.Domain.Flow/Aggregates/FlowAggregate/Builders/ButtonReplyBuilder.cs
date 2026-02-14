using ChatBot.Domain.Flow.Aggregates.FlowAggregate.Buttons;
using ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Builders;

public readonly record struct ButtonReplyBuilder
{
    private string Id { get; init; }
    private string Title { get; init; }

    private TargetNode? TargetNode { get; init; }
    private TargetFlow? TargetFlow { get; init; }

    private ButtonReplyBuilder(string id, string title)
    {
        Id = id;
        Title = title;
        TargetNode = null;
        TargetFlow = null;
    }

    public static ButtonReplyBuilder Builder(string id, string title) => new(id, title);

    public ButtonReplyBuilder WithTargetNode(TargetNode targetNode)
    {
        return this with
        {
            TargetNode = targetNode,
            TargetFlow = null
        };
    }

    public ButtonReplyBuilder WithTargetFlow(TargetFlow targetFlow)
    {
        return this with
        {
            TargetNode = null,
            TargetFlow = targetFlow
        };
    }

    public ButtonReply Build()
    {
        if (string.IsNullOrWhiteSpace(Id))
            throw new InvalidOperationException("O ID do botão é obrigatório.");

        if (string.IsNullOrWhiteSpace(Title))
            throw new InvalidOperationException("O Título do botão é obrigatório.");

        return new ButtonReply(Id, Title, TargetNode, TargetFlow);
    }
}