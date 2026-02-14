namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Buttons;

public readonly record struct ListButtonConfig(ButtonText ButtonText, List<SectionButton> SubdivisionsButtons);
