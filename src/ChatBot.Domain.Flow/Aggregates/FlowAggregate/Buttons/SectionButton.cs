namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Buttons;

public record struct SectionButton(
    string Title,
    List<RowListButton> Rows
);