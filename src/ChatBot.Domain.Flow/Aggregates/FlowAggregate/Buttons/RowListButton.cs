using ChatBot.Domain.Flow.Aggregates.FlowAggregate.ValuesObject;

namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Buttons;

public record struct RowListButton(
    string Id,
    string Title,
    string? Description, 
    NavigationTargetNode? NavigationTargetNode,
    NavigationTargetFlow? NavigationTargetFlow
);