namespace Integrator.ChatFlow.Domain.Aggregates.FlowAggregate.Buttons;

public record struct RowListButton(
    string Id,
    string Title,
    string? Description = null
);