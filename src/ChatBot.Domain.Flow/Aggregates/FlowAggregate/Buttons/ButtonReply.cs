using ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Buttons;

public readonly record struct ButtonReply(
    string Id,
    string Title,
    TargetNode? TargetNode = null,
    TargetFlow? TargetFlow = null
)
{
    public string Type { get; } = "reply";
}