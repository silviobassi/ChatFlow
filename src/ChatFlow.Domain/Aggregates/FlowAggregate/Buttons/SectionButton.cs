namespace ChatFlow.Domain.Aggregates.FlowAggregate.Buttons;

public record struct SectionButton(
    string Title,
    List<RowListButton> Rows
);