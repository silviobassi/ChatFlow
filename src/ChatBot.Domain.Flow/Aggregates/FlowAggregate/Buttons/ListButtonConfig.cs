namespace ChatBot.Domain.Flow.Aggregates.FlowAggregate.Buttons;

public sealed record ListButtonConfig(ButtonText ButtonText, List<SectionButton> SubdivisionsButtons);