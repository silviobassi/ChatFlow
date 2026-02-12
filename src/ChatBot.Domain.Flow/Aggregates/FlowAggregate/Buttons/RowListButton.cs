namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Buttons;

public record struct RowListButton(
    string Id,
    string Title,
    string? Description = null
);