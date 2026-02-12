namespace ChatFlow.Domain.Aggregates.FlowAggregate.Buttons;

public record struct ButtonReply(
    string Id,
    string Title
)
{
    public string Type { get; init; } = "reply";
}